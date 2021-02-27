using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MedecinSpecialiteRepository
    {
        private GestionConsultationEntities context;
        public MedecinSpecialiteRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.MedecinSpecialite> GetAllMedecinSpecialites()
        {
            return context.MedecinSpecialites.ToList();
        }

        public List<DAL.MedecinSpecialite> GetAllMedecinSpecialiteForMedecin(int medecin_ID)
        {
            return context.GetAllMedecinSpecialiteForMedecin(medecin_ID).ToList();
        }

        public DAL.MedecinSpecialite GetMedecinSpecialitebyId(int id)
        {
            var MS = context.GetMedecinSpecialiteById(id).FirstOrDefault();
            return MS;
        }

        public int AddMedecinSpecialite(DAL.MedecinSpecialite medecinSpecialite)
        {
            try
            {
                context.MedecinSpecialites.Add(medecinSpecialite);
                context.SaveChanges();
                return medecinSpecialite.MedecinSpecialite_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void UpdateMedecinSpecialite(DAL.MedecinSpecialite medecinSpecialite)
        {
            DAL.MedecinSpecialite MS = this.GetMedecinSpecialitebyId(medecinSpecialite.MedecinSpecialite_ID);
            MS.Medecin_ID = medecinSpecialite.Medecin_ID;
            MS.Specialite_ID = medecinSpecialite.Specialite_ID;
            context.SaveChanges();
        }

        public void DeleteMedecinSpecialite(DAL.MedecinSpecialite medecinSpecialite)
        {
            context.MedecinSpecialites.Remove(medecinSpecialite);
            context.SaveChanges();
        }
    }
}
