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

        public async Task<ActionResult> GetAllMaisonMedicalForMedecin(int id)
        {
            ViewBag.Medecin_ID = id;
            List<ModelView.MaisonMedicaleForMedecinView> MMSForMedecin = new List<ModelView.MaisonMedicaleForMedecinView>();

            List<Models.MedecinSpecialiteMaisonMedicale> MSMMs = new List<Models.MedecinSpecialiteMaisonMedicale>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Get All MSMM for One medecin GetAllMMSForMedecin
                // ResMSMM
                HttpResponseMessage ResMSMM = await client.GetAsync("api/MedecinSpecialiteMaisonMedicale/GetAllMMSForMedecin/" + id);
                // Loop though the list an construct MaisonMedicaleForMedecinView
                // api/MedecinSpecialiteMaisonMedicale/GetAllMMSForMedecin/{medecin_ID}


                if (ResMSMM.IsSuccessStatusCode)
                {
                    var MSMMResponse = ResMSMM.Content.ReadAsStringAsync().Result;
                    MSMMs = JsonConvert.DeserializeObject<List<Models.MedecinSpecialiteMaisonMedicale>>(MSMMResponse);

                    foreach (var item in MSMMs)
                    {
                        // Get the Medecin
                        HttpResponseMessage ResMed = await client.GetAsync("api/Medecin/" + id);
                        Models.Medecin Med = new Models.Medecin();
                        // Get the MaisonMedicale
                        HttpResponseMessage ResMM = await client.GetAsync("api/MaisonMedicale/" + item.MaisonMedicale_ID);
                        Models.MaisonMedicale MM = new Models.MaisonMedicale();
                        // Get the MedecinSpecialite
                        HttpResponseMessage ResMS = await client.GetAsync("api/MedecinSpecialite/" + item.MedecinSpecialite_ID);
                        Models.MedecinSpecialite MS = new Models.MedecinSpecialite();
                        // Get the Specialite
                        // HttpResponseMessage SpecMM = await client.GetAsync("api/Specialite/" + MS.Specialite_ID);
                        Models.Specialite Spec = new Models.Specialite();
                        // Get the MSMM 
                        Models.MedecinSpecialiteMaisonMedicale MSMM = new Models.MedecinSpecialiteMaisonMedicale();
                        MSMM = item;

                        ModelView.MaisonMedicaleForMedecinView MSMMView = new MaisonMedicaleForMedecinView();

                        if (ResMed.IsSuccessStatusCode && ResMM.IsSuccessStatusCode && ResMS.IsSuccessStatusCode)
                        {
                            Med = JsonConvert.DeserializeObject<Models.Medecin>(ResMed.Content.ReadAsStringAsync().Result);
                            MM = JsonConvert.DeserializeObject<Models.MaisonMedicale>(ResMM.Content.ReadAsStringAsync().Result);
                            MS = JsonConvert.DeserializeObject<Models.MedecinSpecialite>(ResMS.Content.ReadAsStringAsync().Result);

                            HttpResponseMessage SpecMM = await client.GetAsync("api/Specialite/" + MS.Specialite_ID);
                            if (SpecMM.IsSuccessStatusCode)
                            {
                                Spec = JsonConvert.DeserializeObject<Models.Specialite>(SpecMM.Content.ReadAsStringAsync().Result);
                            }

                            MSMMView.Medecin = Med;
                            MSMMView.MaisonMedicale = MM;
                            MSMMView.Specialite = Spec;
                            MSMMView.MS = MS;
                        }

                        MSMMView.MSMM = MSMM;

                        MMSForMedecin.Add(MSMMView);
                    }


                    return View(MMSForMedecin);
                    //var specsResponse = Res.Content.ReadAsStringAsync().Result;
                    //MMSForMedecin = JsonConvert.DeserializeObject<List<Models.PairMaisonMedicalSpecialite>>(specsResponse);
                    //return View(MMSForMedecin);
                }
                return View(MMSForMedecin);
            }
        }

        // GET: Medecin/AddMaisonMedicaleForMedecin/id
        public async Task<ActionResult> AddMaisonMedicaleForMedecin(int id)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Medecin_ID = id;

            List<Models.Specialite> specs = new List<Models.Specialite>();
            List<Models.MaisonMedicale> MM = new List<Models.MaisonMedicale>();
            List<Models.MedecinSpecialite> MS = new List<Models.MedecinSpecialite>();

            MedecinSpecialiteMaisonMedicaleCreate MSMMCreate = new MedecinSpecialiteMaisonMedicaleCreate();
            MSMMCreate.Medecin_ID = id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage SpecRes = await client.GetAsync("api/Medecin/GetAllSpecialiteForMedecin/" + id);
                
                HttpResponseMessage MMRes = await client.GetAsync("api/MaisonMedicale");

                HttpResponseMessage MSRes = await client.GetAsync("api/MedecinSpecialite/GetAllMedecinSpecialiteForMedecin/" + id);

                if (SpecRes.IsSuccessStatusCode && MMRes.IsSuccessStatusCode && MSRes.IsSuccessStatusCode)
                {
                    
                    MSMMCreate.listSpecialiteOfMedecin = JsonConvert.DeserializeObject<List<Models.Specialite>>(SpecRes.Content.ReadAsStringAsync().Result);
                    MSMMCreate.listMaisonMedicale = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(MMRes.Content.ReadAsStringAsync().Result);
                    MS = JsonConvert.DeserializeObject<List<Models.MedecinSpecialite>>(MSRes.Content.ReadAsStringAsync().Result);

                    foreach (var item in MSMMCreate.listSpecialiteOfMedecin)
                    {
                        foreach (var item2 in MS)
                        {
                            if (item2.Specialite_ID == item.Specialite_ID)
                            {
                                MSMMCreate.DicMS.Add(item, item2);
                            }
                        }
                    }
                }
                return View(MSMMCreate);
            }
        }

        // POST: Medecin/AddMedecin
        [HttpPost]
        public async Task<ActionResult> AddMaisonMedicaleForMedecin(ModelView.MedecinSpecialiteMaisonMedicaleCreate MSMMCreate)
        {
            ViewBag.Medecin_ID = MSMMCreate.Medecin_ID;
            try
            {
                using (var client = new HttpClient())
                {
                    Models.MedecinSpecialiteMaisonMedicale MSMM = new Models.MedecinSpecialiteMaisonMedicale();
                    MSMM.MaisonMedicale_ID = MSMMCreate.MaisonMedicale_ID;
                    MSMM.MedecinSpecialite_ID = MSMMCreate.MedecinSpecialite_ID;
                    MSMM.MinimalDuration = MSMMCreate.MinimalDuration;

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var Res = client.PostAsJsonAsync<Models.MedecinSpecialiteMaisonMedicale>("api/MedecinSpecialiteMaisonMedicale/", MSMM);

                    if (Res.Result.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        return RedirectToAction("GetAllMaisonMedicalForMedecin/" + MSMMCreate.Medecin_ID);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = Res.Result.Content.ReadAsAsync<string>().Result;

                        List<Models.Specialite> specs = new List<Models.Specialite>();
                        List<Models.MaisonMedicale> MM = new List<Models.MaisonMedicale>();
                        List<Models.MedecinSpecialite> MS = new List<Models.MedecinSpecialite>();

                        HttpResponseMessage SpecRes = await client.GetAsync("api/Medecin/GetAllSpecialiteForMedecin/" + MSMMCreate.Medecin_ID);

                        HttpResponseMessage MMRes = await client.GetAsync("api/MaisonMedicale");

                        HttpResponseMessage MSRes = await client.GetAsync("api/MedecinSpecialite/GetAllMedecinSpecialiteForMedecin/" + MSMMCreate.Medecin_ID);

                        if (SpecRes.IsSuccessStatusCode && MMRes.IsSuccessStatusCode && MSRes.IsSuccessStatusCode)
                        {

                            MSMMCreate.listSpecialiteOfMedecin = JsonConvert.DeserializeObject<List<Models.Specialite>>(SpecRes.Content.ReadAsStringAsync().Result);
                            MSMMCreate.listMaisonMedicale = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(MMRes.Content.ReadAsStringAsync().Result);
                            MS = JsonConvert.DeserializeObject<List<Models.MedecinSpecialite>>(MSRes.Content.ReadAsStringAsync().Result);

                            foreach (var item in MSMMCreate.listSpecialiteOfMedecin)
                            {
                                foreach (var item2 in MS)
                                {
                                    if (item2.Specialite_ID == item.Specialite_ID)
                                    {
                                        MSMMCreate.DicMS.Add(item, item2);
                                    }
                                }
                            }
                        }
                        return View(MSMMCreate);
                    }
                }
            }
            catch
            {
                return View(MSMMCreate.Medecin_ID);
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
