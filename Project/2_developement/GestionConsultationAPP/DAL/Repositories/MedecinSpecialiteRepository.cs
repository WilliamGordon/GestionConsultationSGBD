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

        public void HandleRequestFrom(string WebClient)
        {
            if (WebClient == "https://localhost:44301")
            {
                this.context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringMedecin"].ConnectionString;
            }
            else if (WebClient == "https://localhost:44349")
            {
                this.context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringPatient"].ConnectionString;
            }
            else
            {
                throw new Exception();
            }
        }

        public List<DAL.MedecinSpecialite> GetAllMedecinSpecialiteForMedecin(int medecin_ID)
        {
            try
            {
                return context.GetAllMedecinSpecialiteForMedecin(medecin_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.MedecinSpecialite GetMedecinSpecialitebyId(int id)
        {
            try
            {
                return context.GetMedecinSpecialiteById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddMedecinSpecialite(DAL.MedecinSpecialite medecinSpecialite)
        {
            try
            {
                return context.AddMedecinSpecialite(medecinSpecialite.Medecin_ID, medecinSpecialite.Specialite_ID).SingleOrDefault().MedecinSpecialite_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
