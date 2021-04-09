using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PatientRepository
    {
        private GestionConsultationEntities context;

        public PatientRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public void HandleRequestFrom(string WebClient)
        {
            if (WebClient == "https://localhost:44301")
            {
                this.context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringMedecin"].ConnectionString;
            }
            else if (WebClient == "https://localhost:44349")
            {
                this.context.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringPatient"].ConnectionString;
            }
            else
            {
                throw new Exception();
            }
        }

        public List<DAL.Patient> GetAllPatients()
        {
            try
            {
                return context.GetAllPatient().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DAL.Patient GetPatientbyId(int id)
        {
            try
            {
                return context.GetPatientById(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPatient(DAL.Patient patient)
        {
            try
            {
                return context.AddPatient(patient.Firstname, patient.Lastname).FirstOrDefault().Patient_ID; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
