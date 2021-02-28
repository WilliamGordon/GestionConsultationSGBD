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
    public class MedecinSpecialiteMaisonMedicaleService
    {
        private MedecinSpecialiteMaisonMedicaleRepository MSMMRepository { get; set; }
        private IMapper Mapper { get; set; }

        public MedecinSpecialiteMaisonMedicaleService()
        {
            MSMMRepository = new MedecinSpecialiteMaisonMedicaleRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public Models.MedecinSpecialiteMaisonMedicale GetMSMMById(int id)
        {
            return Mapper.Map<Models.MedecinSpecialiteMaisonMedicale>(MSMMRepository.GetMedecinSpecialiteMaisonMedicalebyId(id));
        }

        public List<Models.MedecinSpecialiteMaisonMedicale> GetAllMSMMForMedecin(int Medecin_ID)
        {
            return Mapper.Map< List<Models.MedecinSpecialiteMaisonMedicale>>(MSMMRepository.GetAllMMSForMedecin(Medecin_ID));
        }

        public int AddMSMM(Models.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                return MSMMRepository.AddMedecinSpecialiteMaisonMedicale(Mapper.Map<DAL.MedecinSpecialiteMaisonMedicale>(MSMM));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditMSMM(Models.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                return MSMMRepository.UpdateMedecinSpecialiteMaisonMedicale(Mapper.Map<DAL.MedecinSpecialiteMaisonMedicale>(MSMM));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
