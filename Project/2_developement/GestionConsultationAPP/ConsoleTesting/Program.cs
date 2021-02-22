using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GestionConsultationEntities();

            var med = new Medecin();

            med.Firstname = "Achile";
            med.Lastname = "Dachou";

            context.Medecins.Add(med);
            context.SaveChanges();

            Console.WriteLine(med.Medecin_ID);

            var spec = context.GetAllMedecin();

            foreach (var sp in spec)
            {
                Console.WriteLine(sp.Medecin_ID + ")" + sp.Firstname + " " + sp.Lastname);
            }

            Console.ReadLine();
        }
    }
}
