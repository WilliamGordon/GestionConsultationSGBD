using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ConsultationRepository
    {
        private GestionConsultationEntities context;
        public ConsultationRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.Consultation> GetAllConsultations(int maisonMedicale_ID, DateTime day)
        {
            try
            {
                return context.GetAllConsultationForMMForADay(maisonMedicale_ID, day).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Consultation> GetAllConsultations(int medecin_ID, int maisonMedicale_ID, DateTime day)
        {
            try
            {
                return context.GetAllConsultation(medecin_ID, maisonMedicale_ID, day).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Consultation> GetAllConsultationForPatient(int id)
        {
            try
            {
                return context.GetAllConsultationForPatient(id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Consultation> GetAllConsultationForMedecin(int id)
        {
            try
            {
                return context.GetAllConsultationForMedecin(id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DAL.Consultation GetConsultationbyId(int id)
        {
            try
            {
                return context.GetConsultationById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddConsultation(DAL.Consultation consultation)
        {
            try
            {
                return context.AddConsultation(consultation.Patient_ID, consultation.MedecinSpecialiteMaisonMedicale_ID, consultation.Local_ID, consultation.Starting, consultation.Ending).SingleOrDefault().Consultation_ID;
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
                return context.ConfirmConsultation(consultation_ID).FirstOrDefault().Consultation_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateConsultation(DAL.Consultation consultation)
        {
            try
            {
                return context.UpdateConsultation(consultation.Consultation_ID, consultation.Patient_ID, consultation.MedecinSpecialiteMaisonMedicale_ID, consultation.Local_ID, consultation.Starting, consultation.Ending, consultation.IsConfirmed).FirstOrDefault().Consultation_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteConsultation(DAL.Consultation consultation)
        {
            try
            {
                context.DeleteConsultation(consultation.Consultation_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
