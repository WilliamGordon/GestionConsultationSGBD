using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        
        public async Task<ActionResult> GetAllMedecins()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/Medecin");

                    if (response.IsSuccessStatusCode)
                    {
                        return View(JsonConvert.DeserializeObject<List<Models.Medecin>>(response.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = response.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult AddMedecin()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMedecin(ModelView.MedecinCreate medecinCreate)
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
                    var response = await client.PostAsJsonAsync<Models.Medecin>("api/Medecin/", medecin);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllPresenceForMedecin/" + response.Content.ReadAsAsync<int>().Result);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = response.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> GetSpecialiteForMedecin(int id)
        {
            try
            {
                ViewBag.Medecin_ID = id;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/Specialite/GetAllSpecialiteForMedecin/" + id);

                    if (response.IsSuccessStatusCode)
                    {
                        return View(JsonConvert.DeserializeObject<List<Models.Specialite>>(response.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = response.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> AddSpecialiteForMedecin(int id)
        {
            MedecinSpecialiteCreate medSpecCreate = new MedecinSpecialiteCreate();
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string; // catching error messages from the failed post request
                ViewBag.Medecin_ID = id;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/Specialite");

                    if (response.IsSuccessStatusCode)
                    {
                        medSpecCreate.Medecin_ID = id;
                        medSpecCreate.listSpecialite = JsonConvert.DeserializeObject<List<Models.Specialite>>(response.Content.ReadAsStringAsync().Result);
                        return View(medSpecCreate);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = response.Content.ReadAsAsync<string>().Result;
                        return View(medSpecCreate);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(medSpecCreate);
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
                    var response = client.PostAsJsonAsync<Models.MedecinSpecialite>("api/MedecinSpecialite/", medspec);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetSpecialiteForMedecin/" + medSpecCreate.Medecin_ID);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = response.Result.Content.ReadAsAsync<string>().Result;
                        return RedirectToAction("AddSpecialiteForMedecin/" + medSpecCreate.Medecin_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AddSpecialiteForMedecin/" + medSpecCreate.Medecin_ID);
            }
        }

        public async Task<ActionResult> GetAllMaisonMedicalForMedecin(int id)
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string; // catching error messages from the failed post request
            ViewBag.Medecin_ID = id;
            List<ModelView.MaisonMedicaleForMedecinView> MMSForMedecin = new List<ModelView.MaisonMedicaleForMedecinView>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseMSMM = await client.GetAsync("api/MedecinSpecialiteMaisonMedicale/GetAllMMSForMedecin/" + id);

                    // Loop though the list an construct MaisonMedicaleForMedecinView
                    if (responseMSMM.IsSuccessStatusCode)
                    {
                        foreach (var msmm in JsonConvert.DeserializeObject<List<Models.MedecinSpecialiteMaisonMedicale>>(responseMSMM.Content.ReadAsStringAsync().Result))
                        {
                            HttpResponseMessage responseMedecin = await client.GetAsync("api/Medecin/" + id);
                            HttpResponseMessage responseMaisonMedicale = await client.GetAsync("api/MaisonMedicale/" + msmm.MaisonMedicale_ID);
                            HttpResponseMessage responseMedecinSpecialite = await client.GetAsync("api/MedecinSpecialite/" + msmm.MedecinSpecialite_ID);
                            Models.MedecinSpecialite MS = new Models.MedecinSpecialite();
                            Models.Specialite Spec = new Models.Specialite();

                            ModelView.MaisonMedicaleForMedecinView MSMMView = new MaisonMedicaleForMedecinView();

                            if (responseMedecin.IsSuccessStatusCode && responseMaisonMedicale.IsSuccessStatusCode && responseMedecinSpecialite.IsSuccessStatusCode)
                            {
                                MS = JsonConvert.DeserializeObject<Models.MedecinSpecialite>(responseMedecinSpecialite.Content.ReadAsStringAsync().Result);

                                HttpResponseMessage SpecMM = await client.GetAsync("api/Specialite/" + MS.Specialite_ID);
                                if (SpecMM.IsSuccessStatusCode)
                                {
                                    Spec = JsonConvert.DeserializeObject<Models.Specialite>(SpecMM.Content.ReadAsStringAsync().Result);
                                }
                                else
                                {
                                    ViewBag.ErrorMessage = responseMSMM.Content.ReadAsAsync<string>().Result;
                                }

                                MSMMView.Medecin = JsonConvert.DeserializeObject<Models.Medecin>(responseMedecin.Content.ReadAsStringAsync().Result);
                                MSMMView.MaisonMedicale = JsonConvert.DeserializeObject<Models.MaisonMedicale>(responseMaisonMedicale.Content.ReadAsStringAsync().Result);
                                MSMMView.Specialite = Spec;
                                MSMMView.MS = MS;
                                MSMMView.MSMM = msmm;
                                MMSForMedecin.Add(MSMMView);
                            }
                            else
                            {
                                ViewBag.ErrorMessage = responseMSMM.Content.ReadAsAsync<string>().Result;
                            }
                        }
                        return View(MMSForMedecin);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseMSMM.Content.ReadAsAsync<string>().Result;
                        return View(MMSForMedecin);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(MMSForMedecin);
            }
        }

        public async Task<ActionResult> AddMaisonMedicaleForMedecin(int id)
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string; // catching error messages from the failed post request
            ViewBag.Medecin_ID = id;

            try
            {
                MedecinSpecialiteMaisonMedicaleCreate MSMMCreate = new MedecinSpecialiteMaisonMedicaleCreate();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseSpecialite = await client.GetAsync("api/Specialite/GetAllSpecialiteForMedecin/" + id);
                    HttpResponseMessage responseMaisonMedicale = await client.GetAsync("api/MaisonMedicale");
                    HttpResponseMessage responseMedecinSpecialite = await client.GetAsync("api/MedecinSpecialite/GetAllMedecinSpecialiteForMedecin/" + id);

                    if (responseSpecialite.IsSuccessStatusCode && responseMaisonMedicale.IsSuccessStatusCode && responseMedecinSpecialite.IsSuccessStatusCode)
                    {
                        MSMMCreate.Medecin_ID = id;
                        MSMMCreate.listSpecialiteOfMedecin = JsonConvert.DeserializeObject<List<Models.Specialite>>(responseSpecialite.Content.ReadAsStringAsync().Result);
                        MSMMCreate.listMaisonMedicale = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(responseMaisonMedicale.Content.ReadAsStringAsync().Result);

                        foreach (var specialite in MSMMCreate.listSpecialiteOfMedecin)
                        {
                            foreach (var medecinSpecialite in JsonConvert.DeserializeObject<List<Models.MedecinSpecialite>>(responseMedecinSpecialite.Content.ReadAsStringAsync().Result))
                            {
                                if (medecinSpecialite.Specialite_ID == specialite.Specialite_ID)
                                {
                                    MSMMCreate.DicMS.Add(specialite, medecinSpecialite);
                                }
                            }
                        }

                        return View(MSMMCreate);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseSpecialite.Content.ReadAsAsync<string>().Result + " " + responseMaisonMedicale.Content.ReadAsAsync<string>().Result + " " + responseMedecinSpecialite.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

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
                    var response = client.PostAsJsonAsync<Models.MedecinSpecialiteMaisonMedicale>("api/MedecinSpecialiteMaisonMedicale/", MSMM);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        return RedirectToAction("GetAllMaisonMedicalForMedecin/" + MSMMCreate.Medecin_ID);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = response.Result.Content.ReadAsAsync<string>().Result;
                        return RedirectToAction("AddMaisonMedicaleForMedecin/" + MSMMCreate.Medecin_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AddMaisonMedicaleForMedecin/" + MSMMCreate.Medecin_ID);
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditMedecinSpecialiteMaisonMedicale(ModelView.MedecinSpecialiteMaisonMedicaleEdit MSMMEdit)
        {
            ViewBag.Medecin_ID = MSMMEdit.Medecin_ID;

            try
            {
                Models.MedecinSpecialiteMaisonMedicale MSMM = new Models.MedecinSpecialiteMaisonMedicale();
                MSMM.MaisonMedicale_ID = MSMMEdit.MaisonMedicale_ID;
                MSMM.MedecinSpecialiteMaisonMedicale_ID = MSMMEdit.MedecinSpecialiteMaisonMedicale_ID;
                MSMM.MedecinSpecialite_ID = MSMMEdit.MedecinSpecialite_ID;
                MSMM.MinimalDuration = MSMMEdit.MinimalDuration;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PutAsJsonAsync<Models.MedecinSpecialiteMaisonMedicale>("api/MedecinSpecialiteMaisonMedicale/", MSMM);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllMaisonMedicalForMedecin/" + MSMMEdit.Medecin_ID);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = response.Content.ReadAsAsync<string>().Result;
                        return RedirectToAction("GetAllMaisonMedicalForMedecin/" + MSMMEdit.Medecin_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("GetAllMaisonMedicalForMedecin/" + MSMMEdit.Medecin_ID);
            }
        }

        public async Task<ActionResult> GetAllPresenceForMedecin(int id)
        {
            ViewBag.Medecin_ID = id;

            List<ModelView.PresenceForMedecinView> PresencesForMedecin = new List<ModelView.PresenceForMedecinView>();
            List<Models.Presence> Presences = new List<Models.Presence>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage responsePresence = await client.GetAsync("api/Presence/GetAllPresenceForMedecin/" + id);

                    if (responsePresence.IsSuccessStatusCode)
                    {
                        foreach (var item in JsonConvert.DeserializeObject<List<Models.Presence>>(responsePresence.Content.ReadAsStringAsync().Result))
                        {
                            HttpResponseMessage responseMedecin = await client.GetAsync("api/Medecin/" + id);
                            HttpResponseMessage responseMaisonMedicale = await client.GetAsync("api/MaisonMedicale/" + item.MaisonMedicale_ID);

                            if (responseMedecin.IsSuccessStatusCode && responseMaisonMedicale.IsSuccessStatusCode)
                            {
                                var pres = new ModelView.PresenceForMedecinView();
                                pres.Medecin = JsonConvert.DeserializeObject<Models.Medecin>(responseMedecin.Content.ReadAsStringAsync().Result);
                                pres.MaisonMedicale = JsonConvert.DeserializeObject<Models.MaisonMedicale>(responseMaisonMedicale.Content.ReadAsStringAsync().Result);
                                pres.Starting = item.Starting;
                                pres.Ending = item.Ending;

                                PresencesForMedecin.Add(pres);
                            }
                            else
                            {
                                ViewBag.ErrorMessage = responseMedecin.Content.ReadAsAsync<string>().Result + " " + responseMaisonMedicale.Content.ReadAsAsync<string>().Result;
                                return View(PresencesForMedecin);
                            }
                        }
                        return View(PresencesForMedecin);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responsePresence.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> AddPresenceForMedecin(int id)
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string; // catching error messages from the failed post request
            ViewBag.Medecin_ID = id;

            PresenceCreate presenceCreate = new PresenceCreate();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/MaisonMedicale/GetAllMaisonMedicaleForMedecin/" + id);

                    if (response.IsSuccessStatusCode)
                    {
                        presenceCreate.Medecin_ID = id;
                        presenceCreate.ListMMForMedecin = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(response.Content.ReadAsStringAsync().Result);
                        presenceCreate.Medecin_ID = id;
                        
                        return View(presenceCreate);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = response.Content.ReadAsAsync<string>().Result;
                        return View(presenceCreate);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPresenceForMedecin(ModelView.PresenceCreate presenceCreate)
        {
            ViewBag.Medecin_ID = presenceCreate.Medecin_ID;

            List<Models.Presence> presences = new List<Models.Presence>();

            try
            {
                foreach (var day in presenceCreate.days)
                {
                    Models.Presence presence = new Models.Presence();
                    presence.Medecin_ID = presenceCreate.Medecin_ID;
                    presence.MaisonMedicale_ID = presenceCreate.MaisonMedicale_ID;

                    var start = day + " " + presenceCreate.Starting.Hour.ToString().PadLeft(2, '0') + ":" + presenceCreate.Starting.Minute.ToString().PadLeft(2, '0') + ":00";
                    var end = day + " " + presenceCreate.Ending.Hour.ToString().PadLeft(2, '0') + ":" + presenceCreate.Ending.Minute.ToString().PadLeft(2, '0') + ":00";

                    presence.Starting = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    presence.Ending = DateTime.ParseExact(end, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    presences.Add(presence);
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsJsonAsync<List<Models.Presence>>("api/Presence/", presences);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllPresenceForMedecin/" + presenceCreate.Medecin_ID);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = response.Content.ReadAsAsync<string>().Result;
                        return RedirectToAction("AddPresenceForMedecin/" + presenceCreate.Medecin_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AddPresenceForMedecin/" + presenceCreate.Medecin_ID);
            }
        }

        public async Task<ActionResult> GetAllConsultationForMedecin(int id)
        {
            ViewBag.Medecin_ID = id;

            List<ModelView.ConsultationView> consultations = new List<ModelView.ConsultationView>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseConsultation = await client.GetAsync("api/Consultation/GetAllConsultationForMedecin/" + id);

                    if (responseConsultation.IsSuccessStatusCode)
                    {
                        foreach (var consultation in JsonConvert.DeserializeObject<List<Models.Consultation>>(responseConsultation.Content.ReadAsStringAsync().Result))
                        {
                            HttpResponseMessage responseMaisonMedicale = await client.GetAsync("api/MaisonMedicale//GetMaisonMedicaleFromMSMM/" + consultation.MedecinSpecialiteMaisonMedicale_ID);
                            HttpResponseMessage responsePatient = await client.GetAsync("api/Patient/" + consultation.Patient_ID);
                            HttpResponseMessage responseSpecialite = await client.GetAsync("api/Specialite/GetSpecialiteFromMSMM/" + consultation.MedecinSpecialiteMaisonMedicale_ID);
                            HttpResponseMessage responseLocale = await client.GetAsync("api/Local/" + consultation.Local_ID);

                            if (responseMaisonMedicale.IsSuccessStatusCode && responsePatient.IsSuccessStatusCode && responseSpecialite.IsSuccessStatusCode && responseLocale.IsSuccessStatusCode)
                            {
                                consultations.Add(new ConsultationView()
                                {
                                    Consultation = consultation,
                                    MaisonMedicale = JsonConvert.DeserializeObject<Models.MaisonMedicale>(responseMaisonMedicale.Content.ReadAsStringAsync().Result),
                                    Patient = JsonConvert.DeserializeObject<Models.Patient>(responsePatient.Content.ReadAsStringAsync().Result),
                                    Specialite = JsonConvert.DeserializeObject<Models.Specialite>(responseSpecialite.Content.ReadAsStringAsync().Result),
                                    Local = JsonConvert.DeserializeObject<Models.Local>(responseLocale.Content.ReadAsStringAsync().Result),
                                });
                            }
                            else
                            {
                                ViewBag.ErrorMessage = responseMaisonMedicale.Content.ReadAsAsync<string>().Result + " " + responsePatient.Content.ReadAsAsync<string>().Result + " " + responseSpecialite.Content.ReadAsAsync<string>().Result + " " + responseLocale.Content.ReadAsAsync<string>().Result;
                                return View();
                            }
                        }
                        return View(consultations);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseConsultation.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
