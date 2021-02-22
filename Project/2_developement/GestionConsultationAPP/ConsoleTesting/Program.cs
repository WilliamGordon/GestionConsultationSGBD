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
            var spec = context.Specialites.ToList();

            foreach (var sp in spec)
            {
                Console.WriteLine(sp.Name);
            }

            Console.ReadLine();
        }
    }
}
