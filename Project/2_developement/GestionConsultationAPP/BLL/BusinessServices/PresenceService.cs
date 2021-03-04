using AutoMapper;
using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessServices
{
    public class PresenceService
    {
        public DAL.Repositories.PresenceRepository presenceRepo { get; set; }
        private IMapper Mapper { get; set; }

        public PresenceService()
        {
            presenceRepo = new DAL.Repositories.PresenceRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.Presence> GetAllPresence(int medecin_ID, int maisonMedicale_ID, DateTime day)
        {
            try
            {
                List<DAL.Presence> DALPres = presenceRepo.GetAllPresences(medecin_ID, maisonMedicale_ID, day);
                List<Models.Presence> pres = Mapper.Map<List<Models.Presence>>(DALPres);
                return pres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPresence(List<Models.Presence> presence)
        {
            foreach (var pres in presence)
            {
                presenceRepo.AddPresence(Mapper.Map<DAL.Presence>(pres));
            }
            return 0;
        }

        public List<Models.Presence> GetAllPresenceForMedecin(int Medecin_ID)
        {
            try
            {
                List<DAL.Presence> DALPres = presenceRepo.GetAllPresenceForMedecin(Medecin_ID);
                List<Models.Presence> pres = Mapper.Map<List<Models.Presence>>(DALPres);
                return pres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
