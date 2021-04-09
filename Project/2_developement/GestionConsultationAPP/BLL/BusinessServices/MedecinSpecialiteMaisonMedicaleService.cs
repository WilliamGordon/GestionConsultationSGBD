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
        public void HandleRequestOrigin(string WebClient)
        {
            MSMMRepository.HandleRequestFrom(WebClient);
        }

        public Models.MedecinSpecialiteMaisonMedicale GetMSMMById(int msmm_ID)
        {
            try
            {
                return Mapper.Map<Models.MedecinSpecialiteMaisonMedicale>(MSMMRepository.GetMedecinSpecialiteMaisonMedicalebyId(msmm_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.MedecinSpecialiteMaisonMedicale> GetAllMSMMForMedecin(int medecin_ID)
        {
            try
            {
                return Mapper.Map<List<Models.MedecinSpecialiteMaisonMedicale>>(MSMMRepository.GetAllMMSForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddMedecinSpecialiteMaisonMedicale(Models.MedecinSpecialiteMaisonMedicale MSMM)
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

        public int UpdateMedecinSpecialiteMaisonMedicale(Models.MedecinSpecialiteMaisonMedicale MSMM)
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
