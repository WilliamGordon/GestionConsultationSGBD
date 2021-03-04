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
    public class SpecialiteService
    {
        private SpecialiteRepository SpecRepository { get; set; }
        private IMapper Mapper { get; set; }
        public SpecialiteService()
        {
            SpecRepository = new SpecialiteRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }
        public List<Models.Specialite> GetAllSpecialites()
        {
            List<DAL.Specialite> DALspecs = SpecRepository.GetAllSpecialites();
            List<Models.Specialite> specs = Mapper.Map<List<Models.Specialite>>(DALspecs);
            return specs;
        }

        public List<Models.Specialite> GetAllSpecialiteForMaisonMedicale(int id)
        {
            List<DAL.Specialite> DALspecs = SpecRepository.GetAllSpecialiteForMaisonMedicale(id);
            List<Models.Specialite> specs = Mapper.Map<List<Models.Specialite>>(DALspecs);
            return specs;
        }

        
        public Models.Specialite GetSpecialiteFromMSMM(int id)
        {
            return Mapper.Map<Models.Specialite>(SpecRepository.GetSpecialiteFromMSMM(id));
        }
        public Models.Specialite GetSpecialiteById(int id)
        {
            return Mapper.Map<Models.Specialite>(SpecRepository.GetSpecialiteById(id));
        }
    }
}
