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
        private MedecinRepository medecinRepository { get; set; }
        private IMapper Mapper { get; set; }
        public MedecinService()
        {
            medecinRepository = new MedecinRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public void HandleRequestOrigin(string WebClient)
        {
            medecinRepository.HandleRequestFrom(WebClient);
        }

        public List<Models.Medecin> GetAllMedecins()
        {
            try
            {
                return Mapper.Map<List<Models.Medecin>>(medecinRepository.GetAllMedecins());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Medecin> GetAllMedecinForMaisonMedicaleAndSpecialite(int maisonMedicale_ID, int specialite_ID)
        {
            try
            {
                return Mapper.Map<List<Models.Medecin>>(medecinRepository.GetAllMedecinForMaisonMedicaleAndSpecialite(maisonMedicale_ID, specialite_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Models.Medecin GetMedecinFromMSMM(int msmm_ID)
        {
            try
            {
                return Mapper.Map<Models.Medecin>(medecinRepository.GetMedecinFromMSMM(msmm_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Models.Medecin GetMedecinById(int medecin_ID)
        {
            try
            {
                return Mapper.Map<Models.Medecin>(medecinRepository.GetMedecinbyId(medecin_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddMedecin(Models.Medecin medecin)
        {
            try
            {
                return medecinRepository.AddMedecin(Mapper.Map<DAL.Medecin>(medecin));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
