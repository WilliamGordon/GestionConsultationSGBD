using BLL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            MedecinService MBS = new MedecinService();
            var medecins = MBS.GetAllMedecins();
            foreach (var med in medecins)
            {
                Console.WriteLine(med.Firstname + " " + med.Lastname);
            }
        }
    }
}
