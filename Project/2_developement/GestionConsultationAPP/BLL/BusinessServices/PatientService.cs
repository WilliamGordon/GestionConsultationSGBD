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
    public class PatientService
    {
        private PatientRepository Repository { get; set; }
        private IMapper Mapper { get; set; }
        public PatientService()
        {
            Repository = new PatientRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.Patient> GetAllPatients()
        {
            List<DAL.Patient> DALpatients = Repository.GetAllPatients();
            List<Models.Patient> patients = Mapper.Map<List<Models.Patient>>(DALpatients);
            return patients;
        }

        public Models.Patient GetPatientById(int id)
        {
            DAL.Patient DALpatient = Repository.GetPatientbyId(id);
            Models.Patient patient = Mapper.Map<Models.Patient>(DALpatient);
            return patient;
        }

        public int AddPatient(Models.Patient medecin)
        {
            return Repository.AddPatient(Mapper.Map<DAL.Patient>(medecin));
        }
    }
}
