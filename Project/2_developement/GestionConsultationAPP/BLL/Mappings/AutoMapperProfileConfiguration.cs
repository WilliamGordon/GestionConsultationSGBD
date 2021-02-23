using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappings
{
    class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<DAL.Medecin, Models.Medecin>();
            CreateMap<Models.Medecin, DAL.Medecin>();

            CreateMap<DAL.Patient, Models.Patient>();
            CreateMap<Models.Patient, DAL.Patient>();

            CreateMap<DAL.MedecinSpecialite, Models.MedecinSpecialite>();
            CreateMap<Models.MedecinSpecialite, DAL.MedecinSpecialite>();
        }
    }
}
