using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PresenceRepository
    {
        private GestionConsultationEntities context;
        public PresenceRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.Presence> GetAllPresences(int medecin_ID, int maisonMedicale_ID, DateTime day)
        {
            try
            {
                return context.GetAllPresence(medecin_ID, maisonMedicale_ID, day).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.Presence GetPresencebyId(int id)
        {
            try
            {
                return context.GetPresenceById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DAL.Presence> GetAllPresenceForMedecin(int medecin_ID)
        {
            try
            {
                return context.GetAllPresenceForMedecin(medecin_ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPresence(DAL.Presence presence)
        {
            try
            {
                return context.AddPresence(presence.Medecin_ID, presence.MaisonMedicale_ID, presence.Starting, presence.Ending).SingleOrDefault().Presence_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
