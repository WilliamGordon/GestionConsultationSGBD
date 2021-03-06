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

            CreateMap<DAL.Specialite, Models.Specialite>();
            CreateMap<Models.Specialite, DAL.Specialite>();

            CreateMap<DAL.MaisonMedicale, Models.MaisonMedicale>();
            CreateMap<Models.MaisonMedicale, DAL.MaisonMedicale>();

            CreateMap<DAL.MedecinSpecialiteMaisonMedicale, Models.MedecinSpecialiteMaisonMedicale>();
            CreateMap<Models.MedecinSpecialiteMaisonMedicale, DAL.MedecinSpecialiteMaisonMedicale>();

            CreateMap<DAL.Presence, Models.Presence>();
            CreateMap<Models.Presence, DAL.Presence>();

            CreateMap<DAL.Consultation, Models.Consultation>();
            CreateMap<Models.Consultation, DAL.Consultation>();

            CreateMap<DAL.Local, Models.Local>();
            CreateMap<Models.Local, DAL.Local>();
        }
    }
}
