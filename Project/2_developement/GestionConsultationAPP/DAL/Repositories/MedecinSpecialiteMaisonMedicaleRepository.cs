using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MedecinSpecialiteMaisonMedicaleRepository
    {
        private GestionConsultationEntities context;
        public MedecinSpecialiteMaisonMedicaleRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.MedecinSpecialiteMaisonMedicale> GetAllMedecinSpecialiteMaisonMedicales()
        {
            return context.MedecinSpecialiteMaisonMedicales.ToList();
        }

        public DAL.MedecinSpecialiteMaisonMedicale GetMedecinSpecialiteMaisonMedicalebyId(int id)
        {
            return context.GetMedecinSpecialiteMaisonMedicaleById(id).FirstOrDefault();
        }

        public List<DAL.MaisonMedicale> GetAllMaisonMedicaleForMedecin(int id)
        {
            return context.GetAllMaisonMedicaleForMedecin(id).ToList();
        }

        public List<DAL.Specialite> GetAllSpecialiteForAMedecinAndMaisonMedicale(int Medecin_ID, int MaisonMedicale_ID)
        {
            return context.GetAllSpecialiteForAMedecinAndMaisonMedicale(Medecin_ID, MaisonMedicale_ID).ToList();
        }

        public List<DAL.MedecinSpecialiteMaisonMedicale> GetAllMMSForMedecin(int MaisonMedicale_ID)
        {
            return context.GetAllMMSForMedecin(MaisonMedicale_ID).ToList();
        }

        public int AddMedecinSpecialiteMaisonMedicale(DAL.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                context.MedecinSpecialiteMaisonMedicales.Add(MSMM);
                context.SaveChanges();
                return MSMM.MedecinSpecialiteMaisonMedicale_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateMedecinSpecialiteMaisonMedicale(DAL.MedecinSpecialiteMaisonMedicale MSMM)
        {
            try
            {
                DAL.MedecinSpecialiteMaisonMedicale msmm = this.GetMedecinSpecialiteMaisonMedicalebyId(MSMM.MedecinSpecialiteMaisonMedicale_ID);
                msmm.MedecinSpecialite_ID = MSMM.MedecinSpecialite_ID;
                msmm.MaisonMedicale_ID = MSMM.MaisonMedicale_ID;
                msmm.MinimalDuration = MSMM.MinimalDuration;
                msmm.IsActif = MSMM.IsActif;
                context.SaveChanges();
                return MSMM.MedecinSpecialiteMaisonMedicale_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMedecinSpecialiteMaisonMedicale(DAL.MedecinSpecialiteMaisonMedicale MSMM)
        {
            context.MedecinSpecialiteMaisonMedicales.Remove(MSMM);
            context.SaveChanges();
        }
    }
}
