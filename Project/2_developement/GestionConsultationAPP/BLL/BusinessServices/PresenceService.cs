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
        public DAL.Repositories.PresenceRepository presenceRepository { get; set; }
        private IMapper Mapper { get; set; }

        public PresenceService()
        {
            presenceRepository = new DAL.Repositories.PresenceRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public void HandleRequestOrigin(string WebClient)
        {
            presenceRepository.HandleRequestFrom(WebClient);
        }

        public List<Models.Presence> GetAllPresenceForMedecin(int medecin_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Presence>>(presenceRepository.GetAllPresenceForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPresence(List<Models.Presence> presences)
        {
            try
            {
                var presence_ID = 0;
                foreach (var pres in presences)
                {
                    presence_ID = presenceRepository.AddPresence(Mapper.Map<DAL.Presence>(pres));
                }
                return presence_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
