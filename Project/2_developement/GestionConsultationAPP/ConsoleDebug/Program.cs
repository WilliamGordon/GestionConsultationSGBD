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
            BLL.BusinessServices.MedecinSpecialiteService rep = new BLL.BusinessServices.MedecinSpecialiteService();

            var test = new Models.MedecinSpecialite();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var SpecMM = client.GetAsync("api/Specialite/28").Result;

                Console.WriteLine(SpecMM.Content.ReadAsStringAsync());

            }

            Console.ReadLine();
        }

    }
}
