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
        private SpecialiteRepository specialiteRepository { get; set; }
        private IMapper Mapper { get; set; }
        public SpecialiteService()
        {
            specialiteRepository = new SpecialiteRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public void HandleRequestOrigin(string WebClient)
        {
            specialiteRepository.HandleRequestFrom(WebClient);
        }

        public List<Models.Specialite> GetAllSpecialites()
        {
            try
            {
                return Mapper.Map<List<Models.Specialite>>(specialiteRepository.GetAllSpecialites());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Specialite> GetAllSpecialiteForMaisonMedicale(int maisonMedicale_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Specialite>>(specialiteRepository.GetAllSpecialiteForMaisonMedicale(maisonMedicale_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Specialite> GetAllSpecialiteForMedecin(int medecin_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Specialite>>(specialiteRepository.GetAllSpecialiteForMedecin(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.Specialite GetSpecialiteFromMSMM(int msmm_ID)
        {
            try
            {
                return Mapper.Map<Models.Specialite>(specialiteRepository.GetSpecialiteFromMSMM(msmm_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.Specialite GetSpecialiteById(int specialite_ID)
        {
            try
            {
                return Mapper.Map<Models.Specialite>(specialiteRepository.GetSpecialiteById(specialite_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
