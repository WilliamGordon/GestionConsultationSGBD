using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LocalRepository
    {
        private GestionConsultationEntities context;
        public LocalRepository()
        {
            this.context = new GestionConsultationEntities();
        }

        public List<DAL.Local> GetAllLocals()
        {
            return context.Locals.ToList();
        }

        public DAL.Local GetLocalbyId(int id)
        {
            return context.GetLocalById(id).FirstOrDefault();
        }

        public int AddLocal(DAL.Local local)
        {
            context.Locals.Add(local);
            context.SaveChanges();
            return local.Local_ID;
        }

        public void UpdateLocal(DAL.Local local)
        {
            DAL.Local MM = this.GetLocalbyId(local.Local_ID);
            MM.Name = local.Name;
            context.SaveChanges();
        }

        public void DeleteLocal(DAL.Local local)
        {
            context.Locals.Remove(local);
            context.SaveChanges();
        }
    }
}
