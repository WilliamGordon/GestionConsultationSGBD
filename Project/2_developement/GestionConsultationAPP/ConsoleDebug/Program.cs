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
            BLL.BusinessServices.PresenceService presService = new BLL.BusinessServices.PresenceService();
            BLL.BusinessServices.MedecinSpecialiteMaisonMedicaleService MSMMService = new BLL.BusinessServices.MedecinSpecialiteMaisonMedicaleService();
            BLL.BusinessServices.ConsultationService consultationService = new BLL.BusinessServices.ConsultationService();

            // Get all presence for medecin for maison medicale for specialite for a DAY
            var pres = presService.GetAllPresence(5, 3, DateTime.ParseExact("2021-03-03 00:00:00", "yyyy-MM-dd HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture));

            Console.WriteLine();
            Console.WriteLine("ALL PRESENCE FOR 03-03");
            Console.WriteLine();
            foreach (var p in pres)
            {
                Console.WriteLine(p.Starting);
                Console.WriteLine(p.Ending);
                Console.WriteLine("----------");
            }

            // Get all consultation for medecin for maison medicale for a DAY

            var cons = consultationService.GetConsultations(5, 3, DateTime.ParseExact("2021-03-03 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
            Console.WriteLine();
            Console.WriteLine("ALL CONSULTATION FOR 03-03");
            Console.WriteLine();
            foreach (var c in cons)
            {
                Console.WriteLine(c.Starting);
                Console.WriteLine(c.Ending);
                Console.WriteLine("----------");
            }

            List<Models.Consultation> listeOfPossibleConsultation = new List<Models.Consultation>();

            var endingOfLastOverlappingConsultation = new DateTime();
            // Get the minimal duration of a consultation for a medecin in a maison medicale
            
            // ALGO

            // Looping through all the presence
            foreach (var p in pres)
            {
                // small check to be sure to not create an infinit loop
                if (p.Starting < p.Ending)
                {

                    DateTime timeTracker = DateTime.ParseExact(p.Starting.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    // Loopthroug the presence with by the number of minutes of a consultation (45 min)
                    while (timeTracker.AddMinutes(45) < p.Ending)
                    {
                        Models.Consultation possibleConsultation = new Models.Consultation();
                        possibleConsultation.Local_ID = 1;
                        possibleConsultation.Patient_ID = 4;
                        possibleConsultation.MedecinSpecialiteMaisonMedicale_ID = 7;
                        possibleConsultation.IsConfirmed = false;
                        possibleConsultation.Starting = timeTracker;
                        possibleConsultation.Ending = timeTracker.AddMinutes(45);

                        bool flag = false;
                        
                        // Check if there is any other consultation during this time by looping over all the consultation
                        foreach (var c in cons)
                        {
                            if(possibleConsultation.Starting < c.Ending && c.Starting < possibleConsultation.Ending)
                            {
                                endingOfLastOverlappingConsultation = c.Ending;
                                flag = true;
                            }
                        }

                        if(flag)
                        {
                            timeTracker = DateTime.ParseExact(endingOfLastOverlappingConsultation.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            flag = false;
                        }
                        else
                        {
                            listeOfPossibleConsultation.Add(possibleConsultation);
                            // Increment the timer
                            timeTracker = timeTracker.AddMinutes(45);
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("ALL POSSIBLE CONSULTATION FOR 03-03");
            Console.WriteLine();
            foreach (var c in listeOfPossibleConsultation)
            {
                Console.WriteLine(c.Starting);
                Console.WriteLine(c.Ending);
                Console.WriteLine("----------");
            }

            Console.ReadLine();
        }

    }
}
