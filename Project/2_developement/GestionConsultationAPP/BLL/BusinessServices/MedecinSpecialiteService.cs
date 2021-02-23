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
        private MedecinSpecialiteRepository Repository { get; set; }
        private IMapper Mapper { get; set; }
        public MedecinSpecialiteService()
        {
            Repository = new MedecinSpecialiteRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public int AddSpecialiteForMedecin(Models.Medecin medecin, Models.Specialite specialite)
        {
            DAL.MedecinSpecialite MS = new DAL.MedecinSpecialite();
            MS.Medecin_ID = medecin.Medecin_ID;
            MS.Specialite_ID = specialite.Specialite_ID;
            return Repository.AddMedecinSpecialite(MS); ;
        }
    }
}
