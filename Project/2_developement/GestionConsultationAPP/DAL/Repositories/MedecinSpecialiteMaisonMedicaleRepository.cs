using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MedecinSpecialiteMaisonMedicaleRepository
    {
        private GestionConsultationEntities context;
        public MedecinSpecialiteMaisonMedicaleRepository()
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

        public List<DAL.MedecinSpecialiteMaisonMedicale> GetAllMedecinSpecialiteMaisonMedicales()
        {
            try
            {
                return context.MedecinSpecialiteMaisonMedicales.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.MedecinSpecialiteMaisonMedicale GetMedecinSpecialiteMaisonMedicalebyId(int id)
        {
            try
            {
                return context.GetMedecinSpecialiteMaisonMedicaleById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.MedecinSpecialiteMaisonMedicale GetMedecinSpecialiteMaisonMedicale(int medecin_ID, int maisonMedicale_ID, int specialite_ID)
        {
            try
            {
                return context.GetMedecinSpecialiteMaisonMedicale(medecin_ID, maisonMedicale_ID, specialite_ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.MaisonMedicale> GetAllMaisonMedicaleForMedecin(int id)
        {
            try
            {
                return context.GetAllMaisonMedicaleForMedecin(id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Specialite> GetAllSpecialiteForAMedecinAndMaisonMedicale(int Medecin_ID, int MaisonMedicale_ID)
        {
            try
            {
                return context.GetAllSpecialiteForAMedecinAndMaisonMedicale(Medecin_ID, MaisonMedicale_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.MedecinSpecialiteMaisonMedicale> GetAllMMSForMedecin(int MaisonMedicale_ID)
        {
            try
            {
                return context.GetAllMMSForMedecin(MaisonMedicale_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddMedecinSpecialiteMaisonMedicale(DAL.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                return context.AddMedecinSpecialiteMaisonMedicale(MSMM.MedecinSpecialite_ID, MSMM.MaisonMedicale_ID, MSMM.MinimalDuration, MSMM.IsActif).SingleOrDefault().MedecinSpecialiteMaisonMedicale_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateMedecinSpecialiteMaisonMedicale(DAL.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                return context.UpdateMinimalDurationOfConsultation(MSMM.MedecinSpecialiteMaisonMedicale_ID, MSMM.MinimalDuration).SingleOrDefault().MedecinSpecialiteMaisonMedicale_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
