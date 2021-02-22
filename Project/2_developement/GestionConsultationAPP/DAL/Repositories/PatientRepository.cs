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

        public List<DAL.Patient> GetAllPatients()
        {
            return context.Patients.ToList();
        }

        public DAL.Patient GetPatientbyId(int id)
        {
            return context.GetPatientById(id).FirstOrDefault();
        }

        public int AddPatient(DAL.Patient Patient)
        {
            int Patient_ID = context.Patients.Add(Patient).Patient_ID;
            context.SaveChanges();
            return Patient_ID;
        }

        public void UpdatePatient(DAL.Patient Patient)
        {
            DAL.Patient med = this.GetPatientbyId(Patient.Patient_ID);
            med.Firstname = Patient.Firstname;
            med.Lastname = Patient.Lastname;
            context.SaveChanges();
        }

        public void DeletePatient(DAL.Patient Patient)
        {
            context.Patients.Remove(Patient);
        }
    }
}
