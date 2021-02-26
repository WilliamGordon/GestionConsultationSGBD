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
            ViewBag.Medecin_ID = id;
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

        // GET: Medecin/AddMedecin
        public ActionResult AddMedecin()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        // POST: Medecin/AddMedecin
        [HttpPost]
        public ActionResult AddMedecin(ModelView.MedecinCreate medecinCreate)
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
                    var Res = client.PostAsJsonAsync<Models.Medecin>("api/Medecin/", medecin);

                    if (Res.Result.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        return RedirectToAction("GetDashboardMedecin/" + Res.Result.Content.ReadAsAsync<int>().Result);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = Res.Result.Content.ReadAsAsync<string>().Result;
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
            ViewBag.Medecin_ID = id;
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
                    return View(specs);
                }
                return View(specs);
            }
        }

        // GET: Medecin/AddSpecialiteForMedecin/id
        public async Task<ActionResult> AddSpecialiteForMedecin(int id)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Medecin_ID = id;
            List<Models.Specialite> specs = new List<Models.Specialite>();
            MedecinSpecialiteCreate sedSpecCreate = new MedecinSpecialiteCreate();
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
                    sedSpecCreate.Medecin_ID = id;
                    sedSpecCreate.listSpecialite = specs;
                }
                return View(sedSpecCreate);
            }
        }

        // POST: Medecin/AddSpecialiteForMedecin
        [HttpPost]
        public async Task<ActionResult> AddSpecialiteForMedecin(ModelView.MedecinSpecialiteCreate medSpecCreate)
        {
            ViewBag.Medecin_ID = medSpecCreate.Medecin_ID;
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
                    var Res = client.PostAsJsonAsync<Models.MedecinSpecialite>("api/MedecinSpecialite/", medspec);

                    if (Res.Result.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        return RedirectToAction("GetSpecialiteForMedecin/" + medSpecCreate.Medecin_ID);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = Res.Result.Content.ReadAsAsync<string>().Result;
                        List<Models.Specialite> specs = new List<Models.Specialite>();
                        MedecinSpecialiteCreate sedSpecCreate = new MedecinSpecialiteCreate();
                        using (var client2 = new HttpClient())
                        {
                            client2.BaseAddress = new Uri(Baseurl);
                            client2.DefaultRequestHeaders.Clear();
                            client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage Ress = await client2.GetAsync("api/Specialite");

                            if (Ress.IsSuccessStatusCode)
                            {
                                var specsResponse = Ress.Content.ReadAsStringAsync().Result;
                                specs = JsonConvert.DeserializeObject<List<Models.Specialite>>(specsResponse);
                                sedSpecCreate.Medecin_ID = medSpecCreate.Medecin_ID;
                                sedSpecCreate.listSpecialite = specs;
                            }
                            return View(sedSpecCreate);
                        }
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetMaisonMedicaleForMedecin(int id)
        {
            ViewBag.Medecin_ID = id;
            List<Models.MaisonMedicale> maisonMed = new List<Models.MaisonMedicale>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Medecin/GetAllMaisonMedicalForMedecin/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var specsResponse = Res.Content.ReadAsStringAsync().Result;
                    maisonMed = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(specsResponse);
                    return View(maisonMed);
                }
                return View(maisonMed);
            }
        }
    }
}
