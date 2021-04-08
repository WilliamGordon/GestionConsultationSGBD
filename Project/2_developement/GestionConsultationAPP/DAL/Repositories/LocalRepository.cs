using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LocalRepository
    {
        private GestionConsultationEntities context;
        public LocalRepository()
        {
            this.context = new GestionConsultationEntities();
        }
        public DAL.Local GetLocalbyId(int id)
        {
            try
            {
                return context.GetLocalById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Local> GetAllLocals(int msmm_ID)
        {
            try
            {
                return context.GetAllLocalsForMSMM(msmm_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
