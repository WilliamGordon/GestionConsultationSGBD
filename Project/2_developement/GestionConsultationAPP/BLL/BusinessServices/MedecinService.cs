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
        private MedecinRepository MedRepository { get; set; }
        private SpecialiteRepository SpecRepository { get; set; }
        private MedecinSpecialiteRepository MedSpecRepository { get; set; }
        private IMapper Mapper { get; set; }
        public MedecinService()
        {
            MedRepository = new MedecinRepository();
            SpecRepository = new SpecialiteRepository();
            MedSpecRepository = new MedecinSpecialiteRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.Medecin> GetAllMedecins()
        {
            List<DAL.Medecin> DALmedecins = MedRepository.GetAllMedecins();
            List<Models.Medecin> medecins = Mapper.Map<List<Models.Medecin>>(DALmedecins);
            return medecins;
        }

        public Models.Medecin GetMedecinById(int id)
        {
            DAL.Medecin DALmedecin = MedRepository.GetMedecinbyId(id);
            Models.Medecin medecin = Mapper.Map<Models.Medecin>(DALmedecin);
            return medecin;
        }
        public int AddMedecin(Models.Medecin medecin)
        {
            try
            {
                return MedRepository.AddMedecin(Mapper.Map<DAL.Medecin>(medecin));
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
                List<DAL.Specialite> DALspecs = SpecRepository.GetAllSpecialiteForMedecin(medecin_ID);
                List<Models.Specialite> specs = Mapper.Map<List<Models.Specialite>>(DALspecs);
                return specs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddSpecialiteForMedecin(Models.MedecinSpecialite medspec)
        {
           
                DAL.MedecinSpecialite MedSpec = new DAL.MedecinSpecialite();
                MedSpec.Medecin_ID = medspec.Medecin_ID;
                MedSpec.Specialite_ID = medspec.Specialite_ID;
                return MedSpecRepository.AddMedecinSpecialite(MedSpec); ;
            
        }

    }
}
