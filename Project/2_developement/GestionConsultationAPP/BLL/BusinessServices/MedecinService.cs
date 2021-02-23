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
    public class MedecinService
    {
        private MedecinRepository Repository { get; set; }
        private IMapper Mapper { get; set; }
        public MedecinService()
        {
            Repository = new MedecinRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.Medecin> GetAllMedecins()
        {
            List<DAL.Medecin> DALmedecins = Repository.GetAllMedecins();
            List<Models.Medecin> medecins = Mapper.Map<List<Models.Medecin>>(DALmedecins);
            return medecins;
        }

        public Models.Medecin GetMedecinById(int id)
        {
            DAL.Medecin DALmedecin = Repository.GetMedecinbyId(id);
            Models.Medecin medecin = Mapper.Map<Models.Medecin>(DALmedecin);
            return medecin;
        }

        public int AddMedecin(Models.Medecin medecin)
        {
            return Repository.AddMedecin(Mapper.Map<DAL.Medecin>(medecin));
        }
    }
}
