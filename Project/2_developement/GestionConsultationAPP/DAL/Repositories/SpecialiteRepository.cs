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
            try
            {
                return context.GetAllSpecialite().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.Specialite GetSpecialiteById(int id)
        {
            try
            {
                return context.GetSpecialiteById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Specialite> GetAllSpecialiteForMedecin(int Medecin_ID)
        {
            try
            {
                return context.GetAllSpecialiteForMedecin(Medecin_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Specialite> GetAllSpecialiteForMaisonMedicale(int maisonMedicale_ID)
        {
            try
            {
                return context.GetAllSpecialiteForMaisonMedicale(maisonMedicale_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.Specialite GetSpecialiteFromMSMM(int id)
        {
            try
            {
                return context.GetSpecialiteFromMSMM(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
