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
            this.context = new GestionConsultationEntities(); // "name=ConnectionStringMedecin"
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

        public List<DAL.Medecin> GetAllMedecins()
        {
            try
            {
                return context.GetAllMedecin().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.Medecin GetMedecinbyId(int id)
        {
            try
            {
                return context.GetMedecinById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Medecin> GetAllMedecinForMaisonMedicaleAndSpecialite(int maisonMedicale_ID, int specialite_ID)
        {
            try
            {
                return context.GetAllMedecinForMaisonMedicaleAndSpecialite(maisonMedicale_ID, specialite_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.Medecin GetMedecinFromMSMM(int msmm_id)
        {
            try
            {
                return context.GetMedecinFromMSMM(msmm_id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddMedecin(DAL.Medecin medecin)
        {
            try
            {
                return context.AddMedecin(medecin.Firstname, medecin.Lastname).SingleOrDefault().Medecin_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
