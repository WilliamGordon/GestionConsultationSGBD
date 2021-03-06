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
        private DAL.Repositories.LocalRepository Repo { get; set; }

        private IMapper Mapper { get; set; }

        public LocaLService()
        {
            Repo = new DAL.Repositories.LocalRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.Local> GetAllLocals(int msmm_ID)
        {
            return Mapper.Map<List<Models.Local>>(Repo.GetAllLocals(msmm_ID));
        }

        public Models.Local GetLocalById(int id)
        {
            return Mapper.Map<Models.Local>(Repo.GetLocalbyId(id));
        }

    }
}
