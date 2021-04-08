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
        public MaisonMedicaleRepository MaisonMedicaleRepository { get; set; }
        private IMapper Mapper { get; set; }
        public MaisonMedicaleService()
        {
            MaisonMedicaleRepository = new MaisonMedicaleRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.MaisonMedicale> GetAllMaisonMedicales()
        {
            try
            {
                return Mapper.Map<List<Models.MaisonMedicale>>(MaisonMedicaleRepository.GetAllMaisonMedicales());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.MaisonMedicale GetMaisonMedicaleById(int id)
        {
            try
            {
                return Mapper.Map<Models.MaisonMedicale>(MaisonMedicaleRepository.GetMaisonMedicalebyId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.MaisonMedicale GetMaisonMedicaleFromMSMM(int msmm_id)
        {
            try
            {
                return Mapper.Map<Models.MaisonMedicale>(MaisonMedicaleRepository.GetMaisonMedicaleFromMSMM(msmm_id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Models.MaisonMedicale> GetAllMaisonMedicaleForMedecin(int medecin_ID)
        {
            try
            {
                return Mapper.Map<List<Models.MaisonMedicale>>(MaisonMedicaleRepository.GetAllMaisonMedicaleForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
