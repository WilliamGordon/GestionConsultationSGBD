using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL.BusinessServices.PresenceService service = new BLL.BusinessServices.PresenceService();
            BLL.BusinessServices.MedecinSpecialiteMaisonMedicaleService MSMMservuce = new BLL.BusinessServices.MedecinSpecialiteMaisonMedicaleService();
            BLL.BusinessServices.ConsultationService consultationService = new BLL.BusinessServices.ConsultationService();


            foreach (var item in MSMMservuce.GetAllMSMMForMedecin(4))
            {
                Console.WriteLine(item.MedecinSpecialiteMaisonMedicale_ID);
                Console.WriteLine(item.MaisonMedicale_ID);
                Console.WriteLine(item.MinimalDuration);
            }

            

            foreach (var pres in service.GetAllPresenceForMedecin(4))
            {
                Console.WriteLine(pres.Presence_ID);
                Console.WriteLine(pres.Starting);
                Console.WriteLine(pres.Ending);

                DateTime start = pres.Starting;
                DateTime end = pres.Ending;

                DateTime start_cons = start;
                DateTime end_cons = end;

                while (start.AddMinutes(30) < pres.Ending)
                {
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("STARTING: " + start);
                    start = start.AddMinutes(30);
                    Console.WriteLine("ENDING: " + start);

                    // Check if there is a consultation during this time

                    // Get all the consultation of the medecin for this day

                    // if this possible consultation time is inbetween a consultation then discard it and start the looping with a new start date which is the end date of the consultation

                    Console.WriteLine();
                    Console.WriteLine();
                }


            }

            Console.ReadLine();
        }

    }
}
