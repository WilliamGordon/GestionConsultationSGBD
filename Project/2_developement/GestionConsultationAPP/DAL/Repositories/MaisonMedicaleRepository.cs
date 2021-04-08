using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MaisonMedicaleRepository
    {
        private GestionConsultationEntities context;
        public MaisonMedicaleRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.MaisonMedicale> GetAllMaisonMedicales()
        {
            try
            {
                return context.GetAllMaisonMedicale().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.MaisonMedicale GetMaisonMedicalebyId(int id)
        {
            try
            {
                return context.GetMaisonMedicaleById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.MaisonMedicale> GetAllMaisonMedicaleForMedecin(int medecin_ID)
        {
            try
            {
                return context.GetAllMaisonMedicaleForMedecin(medecin_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.MaisonMedicale GetMaisonMedicaleFromMSMM(int id)
        {
            try
            {
                return context.GetMaisonMedicaleFromMSMM(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
