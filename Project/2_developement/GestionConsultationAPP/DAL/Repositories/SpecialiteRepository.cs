using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SpecialiteRepository
    {

        private GestionConsultationEntities context;

        public SpecialiteRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.Specialite> GetAllSpecialites()
        {
            return context.Specialites.ToList();
        }

        public List<DAL.Specialite> GetAllSpecialiteForMedecin(int Medecin_ID)
        {
            return context.GetAllSpecialiteForMedecin(Medecin_ID).ToList();
        }

        public List<DAL.Specialite> GetAllSpecialiteForMaisonMedicale(int maisonMedicale_ID)
        {
            return context.GetAllSpecialiteForMaisonMedicale(maisonMedicale_ID).ToList();
        }

        public DAL.Specialite GetSpecialiteFromMSMM(int id)
        {
            return context.GetSpecialiteFromMSMM(id).FirstOrDefault();
        }

        public DAL.Specialite GetSpecialiteById(int id)
        {
            return context.GetSpecialiteById(id).FirstOrDefault();
        }

        public int AddSpecialite(DAL.Specialite specialite)
        {
            int Specialite_ID = context.Specialites.Add(specialite).Specialite_ID;
            context.SaveChanges();
            return Specialite_ID;
        }

        public void UpdateSpecialite(DAL.Specialite specialite)
        {
            DAL.Specialite spec = this.GetSpecialiteById(specialite.Specialite_ID);
            spec.Name = specialite.Name;
            context.SaveChanges();
        }

        public void DeleteSpecialite(DAL.Specialite specialite)
        {
            context.Specialites.Remove(specialite);
            context.SaveChanges();
        }
    }
}
