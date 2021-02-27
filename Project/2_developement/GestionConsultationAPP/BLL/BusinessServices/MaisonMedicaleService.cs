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
    public class MaisonMedicaleService
    {
        public MaisonMedicaleRepository MMRepository { get; set; }
        private IMapper Mapper { get; set; }
        public MaisonMedicaleService()
        {
            MMRepository = new MaisonMedicaleRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.MaisonMedicale> GetAllMaisonMedicales()
        {
            return Mapper.Map<List<Models.MaisonMedicale>>(MMRepository.GetAllMaisonMedicales());
        }

        public Models.MaisonMedicale GetMaisonMedicaleById(int id )
        {
            return Mapper.Map<Models.MaisonMedicale>(MMRepository.GetMaisonMedicalebyId(id)); 
        }
    }
}
