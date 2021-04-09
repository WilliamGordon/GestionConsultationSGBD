using AutoMapper;
using BLL.Mappings;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessServices
{
    public class MedecinSpecialiteService
    {
        private MedecinSpecialiteRepository medecinSpecialiteRepository { get; set; }
        private IMapper Mapper { get; set; }
        public MedecinSpecialiteService()
        {
            medecinSpecialiteRepository = new MedecinSpecialiteRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public void HandleRequestOrigin(string WebClient)
        {
            medecinSpecialiteRepository.HandleRequestFrom(WebClient);
        }

        public List<Models.MedecinSpecialite> GetAllMedecinSpecialiteForMedecin(int medecin_ID)
        {
            try
            {
                return Mapper.Map<List<Models.MedecinSpecialite>>(medecinSpecialiteRepository.GetAllMedecinSpecialiteForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.MedecinSpecialite GetMedecinSpecialitebyId(int medecinSpecialite_ID)
        {
            try
            {
                return Mapper.Map<Models.MedecinSpecialite>(medecinSpecialiteRepository.GetMedecinSpecialitebyId(medecinSpecialite_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddMedecinSpecialite(Models.MedecinSpecialite medspec)
        {
            try
            {
                return medecinSpecialiteRepository.AddMedecinSpecialite(Mapper.Map<DAL.MedecinSpecialite>(medspec));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
