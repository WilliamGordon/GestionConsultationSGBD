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
        private DAL.Repositories.ConsultationRepository Repo { get; set; }
        private BLL.BusinessServices.PresenceService presService { get; set; }
        private BLL.BusinessServices.MedecinSpecialiteMaisonMedicaleService msmmService { get; set; }
        private IMapper Mapper { get; set; }

        public ConsultationService()
        {
            Repo = new DAL.Repositories.ConsultationRepository();
            presService = new BLL.BusinessServices.PresenceService();
            msmmService = new BLL.BusinessServices.MedecinSpecialiteMaisonMedicaleService();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public int AddConsultation(Models.Consultation consultation)
        {
            try
            {
                return Repo.AddConsultation(Mapper.Map<DAL.Consultation>(consultation));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Models.Consultation> GetConsultations(int medecin_ID, int maisonMedicale_ID, DateTime day)
        {
            return Mapper.Map<List<Models.Consultation>>(Repo.GetAllConsultations(medecin_ID, maisonMedicale_ID, day));
        }

        public int ConfirmConsultation(int consultation_ID)
        {
            try
            {
                return Repo.ConfirmConsultation(consultation_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        

        public List<Models.Consultation> GetAllConsultationForMedecin(int id)
        {
            Repo.GetAllConsultationForPatient(id);
            return Mapper.Map<List<Models.Consultation>>(Repo.GetAllConsultationForMedecin(id));
        }

        public List<Models.Consultation> GetAllConsultationForPatient(int id)
        {
            Repo.GetAllConsultationForPatient(id);
            return Mapper.Map<List<Models.Consultation>>(Repo.GetAllConsultationForPatient(id));
        }

        // TODO CHECK IF LOCAL IS AVAILABLE

        public List<Models.Consultation> GetAllPossibleConsultation(int medecin_ID, int maisonMedicale_ID, DateTime day, int specialite_ID, int patient_ID)
        {
            // Get all presence for medecin for maison medicale for a DAY
            var pres = presService.GetAllPresence(medecin_ID, maisonMedicale_ID, day);

            // Get all consultation for medecin for maison medicale for a DAY
            var cons = this.GetConsultations(medecin_ID, maisonMedicale_ID, day);

            // Get the minimal duration of a consultation for a medecin in a maison medicale for one specialite
            var msmm = msmmService.GetMSMMB(medecin_ID, maisonMedicale_ID, specialite_ID);

            List<Models.Consultation> listeOfPossibleConsultation = new List<Models.Consultation>();
            var endingOfLastOverlappingConsultation = new DateTime();

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
                        possibleConsultation.Local_ID = 1;
                        possibleConsultation.Patient_ID = patient_ID;
                        possibleConsultation.MedecinSpecialiteMaisonMedicale_ID = msmm.MedecinSpecialiteMaisonMedicale_ID;
                        possibleConsultation.IsConfirmed = false;
                        possibleConsultation.Starting = timeTracker;
                        possibleConsultation.Ending = timeTracker.AddMinutes(msmm.MinimalDuration);

                        bool flag = false;

                        // Check if there is any other consultation during this time by looping over all the consultation
                        foreach (var c in cons)
                        {
                            if (possibleConsultation.Starting < c.Ending && c.Starting < possibleConsultation.Ending)
                            {
                                endingOfLastOverlappingConsultation = c.Ending;
                                flag = true;
                            }
                        }

                        if (flag)
                        {
                            timeTracker = DateTime.ParseExact(endingOfLastOverlappingConsultation.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            flag = false;
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
            return listeOfPossibleConsultation;
        }
    }
}
