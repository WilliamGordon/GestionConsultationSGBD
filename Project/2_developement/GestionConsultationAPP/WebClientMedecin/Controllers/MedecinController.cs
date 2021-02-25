using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientMedecin.ModelView;

namespace WebClientMedecin.Controllers
{
    public class MedecinController : Controller
    {
        
        public string Baseurl = "https://localhost:44307/";
        // GET: Medecin
        public async Task<ActionResult> GetAllMedecins()
        {
            List<Models.Medecin> medecins = new List<Models.Medecin>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Medecin");

                if(Res.IsSuccessStatusCode)
                {
                    var MedResponse = Res.Content.ReadAsStringAsync().Result;
                    medecins = JsonConvert.DeserializeObject<List<Models.Medecin>>(MedResponse);
                }
                return View(medecins);
            }
        }

        public async Task<ActionResult> SelectMedecins()
        {
            List<Models.Medecin> medecins = new List<Models.Medecin>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Medecin");

                if (Res.IsSuccessStatusCode)
                {
                    var MedResponse = Res.Content.ReadAsStringAsync().Result;
                    medecins = JsonConvert.DeserializeObject<List<Models.Medecin>>(MedResponse);
                }
                return View(medecins);
            }
        }

        // GET: Medecin/Details/5
        public async Task<ActionResult> GetDashboardMedecin(int id)
        {
            Models.Medecin medecin = new Models.Medecin();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Medecin/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var MedResponse = Res.Content.ReadAsStringAsync().Result;
                    medecin = JsonConvert.DeserializeObject<Models.Medecin>(MedResponse);
                }
                return View(medecin);
            }
        }

        // GET: Medecin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medecin/Create
        [HttpPost]
        public ActionResult Create(ModelView.MedecinCreate medecinCreate)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Models.Medecin medecin = new Models.Medecin();
                    medecin.Firstname = medecinCreate.Firstname;
                    medecin.Lastname = medecinCreate.Lastname;

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var Res = client.PostAsJsonAsync<Models.Medecin>("api/Medecin", medecin);

                    if (Res.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetDashboardMedecin/" + Res.Id);
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Medecin
        public async Task<ActionResult> GetPlanning()
        {
            List<Models.Medecin> medecins = new List<Models.Medecin>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Medecin");

                if (Res.IsSuccessStatusCode)
                {
                    var MedResponse = Res.Content.ReadAsStringAsync().Result;
                    medecins = JsonConvert.DeserializeObject<List<Models.Medecin>>(MedResponse);
                }
                return View(medecins);
            }
        }

        // GET: Medecin
        public async Task<ActionResult> GetSpecialiteForMedecin(int id)
        {
            List<Models.Specialite> specs = new List<Models.Specialite>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Medecin/GetAllSpecialiteForMedecin/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var specsResponse = Res.Content.ReadAsStringAsync().Result;
                    specs = JsonConvert.DeserializeObject<List<Models.Specialite>>(specsResponse);
                }
                return View(specs);
            }
        }

        // GET: Medecin/Create
        public async Task<ActionResult> AddSpecialiteForMedecin()
        {
            List<Models.Specialite> specs = new List<Models.Specialite>();
            MedecinSpecialiteCreate MedSpecView = new MedecinSpecialiteCreate();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Specialite");

                if (Res.IsSuccessStatusCode)
                {
                    var specsResponse = Res.Content.ReadAsStringAsync().Result;
                    specs = JsonConvert.DeserializeObject<List<Models.Specialite>>(specsResponse);
                    MedSpecView.listSpecialite = specs;
                }
                return View(MedSpecView);
            }
        }

        // POST: Medecin/Create
        [HttpPost]
        public ActionResult AddSpecialiteForMedecin(ModelView.MedecinSpecialiteCreate medSpecCreate)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Models.MedecinSpecialite medspec = new Models.MedecinSpecialite();
                    medspec.Specialite_ID = medSpecCreate.Specialite_ID;
                    medspec.Medecin_ID = medSpecCreate.Medecin_ID;

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var Res = client.PostAsJsonAsync<Models.MedecinSpecialite>("api/AddSpecialiteForMedecin", medspec);

                    if (Res.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetSpecialiteForMedecin/" + medSpecCreate.Medecin_ID);
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: Medecin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medecin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medecin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
