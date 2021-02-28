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

        public List<DAL.Presence> GetAllPresences()
        {
            return context.Presences.ToList();
        }

        public List<DAL.Presence> GetAllPresenceForMedecin(int medecin_ID)
        {
            return context.GetAllPresenceForMedecin(medecin_ID).ToList();
        }

        public DAL.Presence GetPresencebyId(int id)
        {
            return context.GetPresenceById(id).FirstOrDefault();
        }

        public int AddPresence(DAL.Presence presence)
        {
            context.Presences.Add(presence);
            context.SaveChanges();
            return presence.Presence_ID;
        }

        public void UpdatePresence(DAL.Presence presence)
        {
            DAL.Presence pr = this.GetPresencebyId(presence.Presence_ID);
            pr.Medecin_ID = presence.Medecin_ID;
            pr.MaisonMedicale_ID = presence.MaisonMedicale_ID;
            pr.Starting = presence.Starting;
            pr.Ending = presence.Ending;
            context.SaveChanges();
        }

        public void DeletePresence(DAL.Presence presence)
        {
            context.Presences.Remove(presence);
            context.SaveChanges();
        }
    }
}
