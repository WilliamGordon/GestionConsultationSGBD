using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MedecinRepository
    {
        private GestionConsultationEntities context;
        public MedecinRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.Medecin> GetAllMedecins()
        {
            return context.Medecins.ToList();
        }

        public List<DAL.Medecin> GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay(DateTime day, int maisonMedicale_ID, int specialite_ID)
        {
            return context.GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay(day, maisonMedicale_ID, specialite_ID).ToList();
        }

        public DAL.Medecin GetMedecinbyId(int id)
        {
            return context.GetMedecinById(id).FirstOrDefault();
        }

        public int AddMedecin(DAL.Medecin medecin)
        {
            try
            {
                context.Medecins.Add(medecin);
                context.SaveChanges();
                return medecin.Medecin_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void UpdateMedecin(DAL.Medecin medecin)
        {
            DAL.Medecin med = this.GetMedecinbyId(medecin.Medecin_ID);
            med.Firstname = medecin.Firstname;
            med.Lastname = medecin.Lastname;
            context.SaveChanges();
        }

        public void DeleteMedecin(DAL.Medecin medecin)
        {
            context.Medecins.Remove(medecin);
            context.SaveChanges();
        }
    }
}
