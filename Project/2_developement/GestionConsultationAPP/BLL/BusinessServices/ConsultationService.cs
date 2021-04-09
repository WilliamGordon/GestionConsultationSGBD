using AutoMapper;
using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessServices
{
    public class ConsultationService
    {
        private DAL.Repositories.ConsultationRepository consultationRepository { get; set; }
        private DAL.Repositories.PresenceRepository presRepository { get; set; }
        private DAL.Repositories.MedecinSpecialiteMaisonMedicaleRepository msmmRepository { get; set; }
        private DAL.Repositories.LocalRepository locaRepository { get; set; }
        private DAL.Repositories.MaisonMedicaleRepository maisRepository { get; set; }
        private DAL.Repositories.SpecialiteRepository specRepository { get; set; }
        private IMapper Mapper { get; set; }

        public ConsultationService()
        {
            consultationRepository = new DAL.Repositories.ConsultationRepository();

            presRepository = new DAL.Repositories.PresenceRepository();
            msmmRepository = new DAL.Repositories.MedecinSpecialiteMaisonMedicaleRepository();
            locaRepository = new DAL.Repositories.LocalRepository();
            maisRepository = new DAL.Repositories.MaisonMedicaleRepository();
            specRepository = new DAL.Repositories.SpecialiteRepository();
            
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public void HandleRequestOrigin(string WebClient)
        {
            consultationRepository.HandleRequestFrom(WebClient);
        }

        public List<Models.Consultation> GetAllConsultations(int maisonMedicale_ID, DateTime day)
        {
            try
            {
                return Mapper.Map<List<Models.Consultation>>(consultationRepository.GetAllConsultations(maisonMedicale_ID, day));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Consultation> GetAllConsultations(int medecin_ID, int maisonMedicale_ID, DateTime day)
        {
            try
            {
                return Mapper.Map<List<Models.Consultation>>(consultationRepository.GetAllConsultations(medecin_ID, maisonMedicale_ID, day));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Consultation> GetAllConsultationForPatient(int patient_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Consultation>>(consultationRepository.GetAllConsultationForPatient(patient_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Consultation> GetAllConsultationForMedecin(int medecin_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Consultation>>(consultationRepository.GetAllConsultationForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.Consultation GetConsultationById(int consultation_ID)
        {
            try
            {
                return Mapper.Map<Models.Consultation>(consultationRepository.GetConsultationbyId(consultation_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddConsultation(Models.Consultation consultation)
        {
            try
            {
                return consultationRepository.AddConsultation(Mapper.Map<DAL.Consultation>(consultation));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ConfirmConsultation(int consultation_ID)
        {
            try
            {
                return consultationRepository.ConfirmConsultation(consultation_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateConsultation(Models.Consultation consultation)
        {
            try
            {
                return consultationRepository.UpdateConsultation(Mapper.Map<DAL.Consultation>(consultation));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteConsultation(Models.Consultation consultation)
        {
            try
            {
                consultationRepository.DeleteConsultation(Mapper.Map<DAL.Consultation>(consultation));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Consultation> GetAllPossibleConsultation(int medecin_ID, int maisonMedicale_ID, DateTime day, int specialite_ID, int patient_ID, int consultation_ID = 0)
        {
            try
            {
                // Get all presence for medecin for maison medicale for a DAY
                var pres = presRepository.GetAllPresences(medecin_ID, maisonMedicale_ID, day);

                // Get all consultation for medecin for maison medicale for a DAY
                var cons = this.GetAllConsultations(medecin_ID, maisonMedicale_ID, day);

                // Get the minimal duration of a consultation for a medecin in a maison medicale for one specialite
                var msmm = msmmRepository.GetMedecinSpecialiteMaisonMedicale(medecin_ID, maisonMedicale_ID, specialite_ID);

                List<Models.Consultation> listeOfPossibleConsultation = new List<Models.Consultation>();
                Models.Local local = new Models.Local();
                var endingOfLastOverlappingConsultation = new DateTime();

                // Check if Patient already as a consultation this day in another Maison Medicale
                if (!this.IsPatientAlreadyHasAConsultationInAnotherMaisonMedicale(patient_ID, maisonMedicale_ID, day) || consultation_ID != 0)
                {
                    if (!this.IsPatientAlreadyHasAConsultationForSameSpecialiteInSameMaisonMedicale(patient_ID, maisonMedicale_ID, specialite_ID, day) || consultation_ID != 0)
                    {
                        // Looping through all the presence
                        foreach (var p in pres)
                        {
                            // small check to be sure to not create an infinit loop
                            if (p.Starting < p.Ending)
                            {

                                DateTime timeTracker = DateTime.ParseExact(p.Starting.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                                // Loopthroug the presence by the number of minutes of a consultation
                                while (timeTracker.AddMinutes(msmm.MinimalDuration) <= p.Ending)
                                {
                                    Models.Consultation possibleConsultation = new Models.Consultation();

                                    possibleConsultation.Patient_ID = patient_ID;
                                    possibleConsultation.MedecinSpecialiteMaisonMedicale_ID = msmm.MedecinSpecialiteMaisonMedicale_ID;
                                    possibleConsultation.IsConfirmed = false;
                                    possibleConsultation.Starting = timeTracker;
                                    possibleConsultation.Ending = timeTracker.AddMinutes(msmm.MinimalDuration);

                                    bool IsConsultationOverlapping = false;

                                    // Check if there is any other consultation during this time by looping over all the consultation
                                    foreach (var c in cons)
                                    {
                                        if (possibleConsultation.Starting < c.Ending && c.Starting < possibleConsultation.Ending)
                                        {
                                            endingOfLastOverlappingConsultation = c.Ending;
                                            IsConsultationOverlapping = true;
                                        }
                                    }

                                    bool IsLocalAvailable = true;

                                    // Check if there is an available local for the possible consultation
                                    local = this.GetAvailableLocalForConsultation(possibleConsultation);
                                    if (local == null)
                                    {
                                        // there is no available local
                                        IsLocalAvailable = false;
                                    }
                                    else
                                    {
                                        possibleConsultation.Local_ID = local.Local_ID;
                                    }

                                    if (IsConsultationOverlapping)
                                    {
                                        timeTracker = DateTime.ParseExact(endingOfLastOverlappingConsultation.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                                        IsConsultationOverlapping = false;
                                    }
                                    else if (!IsLocalAvailable)
                                    {
                                        timeTracker = timeTracker.AddMinutes(msmm.MinimalDuration);
                                        IsLocalAvailable = true;
                                    }
                                    else
                                    {
                                        listeOfPossibleConsultation.Add(possibleConsultation);
                                        // Increment the timer
                                        timeTracker = timeTracker.AddMinutes(msmm.MinimalDuration);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new BLL.CustomErrors.PatientAlreadyHasAConsultationForSameSpecialiteInSameMaisonMedicale("Patient already has a consultation with same specialite in this maison médicale");
                    }
                }
                else
                {
                    throw new BLL.CustomErrors.PatientAlreadyHasAConsultationInAnotherMaisonMedicaleException("Patient already has a consultation in another maison médicale");
                }
                if (listeOfPossibleConsultation.Count == 0)
                {
                    throw new BLL.CustomErrors.NoAvailabilityForMedecin("The medecin has not availability for this date");
                }

                return listeOfPossibleConsultation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Models.Consultation> GetAllConsultationForPatientForDay(int patient_ID, DateTime day)
        {
            try
            {
                List<Models.Consultation> consultation = new List<Models.Consultation>();
                foreach (var c in Mapper.Map<List<Models.Consultation>>(consultationRepository.GetAllConsultationForPatient(patient_ID)))
                {
                    if (c.Starting.Date == day.Date)
                    {
                        consultation.Add(c);
                    }
                }
                return consultation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsPatientAlreadyHasAConsultationInAnotherMaisonMedicale(int id, int MM_ID, DateTime day)
        {
            var flag = false;
            foreach (var item in this.GetAllConsultationForPatientForDay(id, day))
            {
                if (maisRepository.GetMaisonMedicaleFromMSMM(item.MedecinSpecialiteMaisonMedicale_ID).MaisonMedicale_ID != MM_ID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private bool IsPatientAlreadyHasAConsultationForSameSpecialiteInSameMaisonMedicale(int id, int MM_ID, int specialite_ID, DateTime day)
        {
            var flag = false;
            foreach (var item in this.GetAllConsultationForPatientForDay(id, day))
            {
                if (maisRepository.GetMaisonMedicaleFromMSMM(item.MedecinSpecialiteMaisonMedicale_ID).MaisonMedicale_ID == MM_ID && specRepository.GetSpecialiteFromMSMM(item.MedecinSpecialiteMaisonMedicale_ID).Specialite_ID == specialite_ID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private Models.Local GetAvailableLocalForConsultation(Models.Consultation possibleConsultation)
        {
            List<Models.Local> availableLocals = new List<Models.Local>();

            // Get All local of Maison medicale with msmm_ID
            List<Models.Local> locals = Mapper.Map<List<Models.Local>>(locaRepository.GetAllLocals(possibleConsultation.MedecinSpecialiteMaisonMedicale_ID));

            // Get All local used during the time of possible consultation
            List<int> IDsOflocalsUsed = new List<int>();

            // Get All consultation For MM For Day
            List<Models.Consultation> consultations = this.GetAllConsultations(locals.FirstOrDefault().MaisonMedicale_ID, possibleConsultation.Starting.Date);

            // Get All consultation which overlap with possible consultation
            foreach (var c in consultations)
            {
                // Is consultation overlapping ?
                if (possibleConsultation.Starting < c.Ending && c.Starting < possibleConsultation.Ending)
                {
                    // if yes then add the local to the used local list
                    IDsOflocalsUsed.Add(c.Local_ID);
                }
            }

            foreach (var local in locals)
            {
                if (!IDsOflocalsUsed.Contains(local.Local_ID))
                {
                    availableLocals.Add(local);
                }
            }

            if (availableLocals.Count >= 1)
            {
                return availableLocals.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
