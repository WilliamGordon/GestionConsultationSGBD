using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MaisonMedicaleRepository
    {
        private GestionConsultationEntities context;
        public MaisonMedicaleRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.MaisonMedicale> GetAllMaisonMedicales()
        {
            return context.MaisonMedicales.ToList();
        }

        public List<DAL.MaisonMedicale> GetAllMaisonMedicaleForMedecin(int medecin_ID)
        {
            return context.GetAllMaisonMedicaleForMedecin(medecin_ID).ToList();
        }

        public DAL.MaisonMedicale GetMaisonMedicalebyId(int id)
        {
            return context.GetMaisonMedicaleById(id).FirstOrDefault();
        }

        public int AddMaisonMedicale(DAL.MaisonMedicale maisonMedicale)
        {
            context.MaisonMedicales.Add(maisonMedicale);
            context.SaveChanges();
            return maisonMedicale.MaisonMedicale_ID;
        }

        public void UpdateMaisonMedicale(DAL.MaisonMedicale maisonMedicale)
        {
            DAL.MaisonMedicale MM = this.GetMaisonMedicalebyId(maisonMedicale.MaisonMedicale_ID);
            MM.Name = maisonMedicale.Name;
            context.SaveChanges();
        }

        public void DeleteMaisonMedicale(DAL.MaisonMedicale maisonMedicale)
        {
            context.MaisonMedicales.Remove(maisonMedicale);
            context.SaveChanges();
        }
    }
}
