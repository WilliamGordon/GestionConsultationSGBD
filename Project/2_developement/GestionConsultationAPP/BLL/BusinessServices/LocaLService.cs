using AutoMapper;
using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessServices
{
    public class LocaLService
    {
        private DAL.Repositories.LocalRepository localRepository { get; set; }

        private IMapper Mapper { get; set; }

        public LocaLService()
        {
            localRepository = new DAL.Repositories.LocalRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public void HandleRequestOrigin(string WebClient)
        {
            localRepository.HandleRequestFrom(WebClient);
        }

        public List<Models.Local> GetAllLocals(int msmm_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Local>>(localRepository.GetAllLocals(msmm_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.Local GetLocalById(int id)
        {
            try
            {
                return Mapper.Map<Models.Local>(localRepository.GetLocalbyId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
