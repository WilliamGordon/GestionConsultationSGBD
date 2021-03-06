﻿using System;
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

        public int ConfirmConsultation(int consultation_ID)
        {
            return context.ConfirmConsultation(consultation_ID).FirstOrDefault().Consultation_ID;
        }

        public List<DAL.Consultation> GetAllConsultations()
        {
            return context.Consultations.ToList();
        }

        public List<DAL.Consultation> GetAllConsultations(int medecin_ID, int maisonMedicale_ID, DateTime day)
        {
            return context.GetAllConsultation(medecin_ID, maisonMedicale_ID, day).ToList();
        }

        public List<DAL.Consultation> GetAllConsultations(int maisonMedicale_ID, DateTime day)
        {
            return context.GetAllConsultationForMMForADay(maisonMedicale_ID, day).ToList();
        }

        public List<DAL.Consultation> GetAllConsultationForPatient(int id)
        {
            return context.GetAllConsultationForPatient(id).ToList();
        }

        public List<DAL.Consultation> GetAllConsultationForMedecin(int id)
        {
            return context.GetAllConsultationForMedecin(id).ToList();
        }
        
        public DAL.Consultation GetConsultationbyId(int id)
        {
            return context.GetConsultationById(id).FirstOrDefault();
        }

        public int AddConsultation(DAL.Consultation consultation)
        {
            context.Consultations.Add(consultation);
            context.SaveChanges();
            return consultation.Consultation_ID;
        }

        public void UpdateConsultation(DAL.Consultation consultation)
        {
            DAL.Consultation cons = this.GetConsultationbyId(consultation.Consultation_ID);
            cons.Patient_ID = consultation.Patient_ID;
            cons.MedecinSpecialiteMaisonMedicale_ID = consultation.MedecinSpecialiteMaisonMedicale_ID;
            cons.MedecinSpecialiteMaisonMedicale_ID = consultation.MedecinSpecialiteMaisonMedicale_ID;
            cons.Local_ID = consultation.Local_ID;
            cons.Starting = consultation.Starting;
            cons.Ending = consultation.Ending;
            cons.IsConfirmed = consultation.IsConfirmed;
            context.SaveChanges();
        }

        public void DeleteConsultation(DAL.Consultation consultation)
        {
            try
            {
                context.Consultations.Attach(consultation);
                context.Consultations.Remove(consultation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
