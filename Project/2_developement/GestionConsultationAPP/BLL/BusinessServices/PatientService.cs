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
        private PatientRepository patientRepository { get; set; }
        private IMapper Mapper { get; set; }
        public PatientService()
        {
            patientRepository = new PatientRepository();

            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }

        public List<Models.Patient> GetAllPatients()
        {
            try
            {
                return Mapper.Map<List<Models.Patient>>(patientRepository.GetAllPatients());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.Patient GetPatientById(int patient_ID)
        {
            try
            {
                return Mapper.Map<Models.Patient>(patientRepository.GetPatientbyId(patient_ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPatient(Models.Patient patient)
        {
            try
            {
                return patientRepository.AddPatient(Mapper.Map<DAL.Patient>(patient));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
