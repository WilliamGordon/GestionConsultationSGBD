using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebClientPatient.Controllers
{
    public class PatientController : Controller
    {
        public string Baseurl = "https://localhost:44307/";

        public async Task<ActionResult> GetAllPatient()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:44349");

                    HttpResponseMessage response = await client.GetAsync("api/Patient");

                    if (response.IsSuccessStatusCode)
                    {
                        return View(JsonConvert.DeserializeObject<List<Models.Patient>>(response.Content.ReadAsStringAsync().Result));
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

        public ActionResult AddPatient()
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
        public async Task<ActionResult> AddPatient(ModelView.PatientCreate patientCreate)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Models.Patient patient = new Models.Patient();
                    patient.Firstname = patientCreate.Firstname;
                    patient.Lastname = patientCreate.Lastname;

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:44349");
                    var response = await client.PostAsJsonAsync<Models.Patient>("api/Patient/", patient);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllConsultationForPatient/" + response.Content.ReadAsAsync<int>().Result);
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

        public async Task<ActionResult> GetConsultationForPatient(int id)
        {
            try
            {
                ViewBag.Patient_ID = id;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:44349");
                    HttpResponseMessage response = await client.GetAsync("api/Consultation/GetAllConsultationForPatient/" + id);

                    if (response.IsSuccessStatusCode)
                    {
                        return View(JsonConvert.DeserializeObject<List<Models.Consultation>>(response.Content.ReadAsStringAsync().Result));
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

        public async Task<ActionResult> AddConsultationForPatient(int id)
        {
            try
            {
                ViewBag.ErrorMessage = "";
                ViewBag.Patient_ID = id;

                ModelView.ConsultationCreate consultationCreate = new ModelView.ConsultationCreate();

                consultationCreate.Patient_ID = id;

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:44349");
                    HttpResponseMessage response = await client.GetAsync("api/MaisonMedicale");

                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        consultationCreate.listMaisonMedicales = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(response.Content.ReadAsStringAsync().Result);
                        return View(consultationCreate);
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

        public async Task<ActionResult> UpdateConsultation(int id)
        {
            try
            {
                ViewBag.ErrorMessage = "";
                ViewBag.Patient_ID = id;

                ModelView.ConsultationCreate consultationCreate = new ModelView.ConsultationCreate();

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:44349");
                    HttpResponseMessage responseMaisonMedicale = await client.GetAsync("api/MaisonMedicale");
                    HttpResponseMessage responseConsultation = await client.GetAsync("api/Consultation/" + id);

                    if (responseMaisonMedicale.IsSuccessStatusCode && responseConsultation.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        consultationCreate = JsonConvert.DeserializeObject<ModelView.ConsultationCreate>(responseConsultation.Content.ReadAsStringAsync().Result);
                        consultationCreate.listMaisonMedicales = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(responseMaisonMedicale.Content.ReadAsStringAsync().Result);
                        ViewBag.Patient_ID = consultationCreate.Patient_ID;

                        HttpResponseMessage responseMaisonMedicaleBis = await client.GetAsync("api/MaisonMedicale//GetMaisonMedicaleFromMSMM/" + consultationCreate.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage responseSpecialite = await client.GetAsync("api/Specialite/GetSpecialiteFromMSMM/" + consultationCreate.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage responseMedecin = await client.GetAsync("api/Medecin/GetMedecinFromMSMM/" + consultationCreate.MedecinSpecialiteMaisonMedicale_ID);

                        if (responseMaisonMedicaleBis.IsSuccessStatusCode && responseSpecialite.IsSuccessStatusCode && responseMedecin.IsSuccessStatusCode)
                        {
                            consultationCreate.MaisonMedicale_ID = JsonConvert.DeserializeObject<Models.MaisonMedicale>(responseMaisonMedicaleBis.Content.ReadAsStringAsync().Result).MaisonMedicale_ID;
                            consultationCreate.Specialite_ID = JsonConvert.DeserializeObject<Models.Specialite>(responseSpecialite.Content.ReadAsStringAsync().Result).Specialite_ID;
                            consultationCreate.Medecin_ID = JsonConvert.DeserializeObject<Models.Medecin>(responseMedecin.Content.ReadAsStringAsync().Result).Medecin_ID;

                            return View("AddConsultationForPatient", consultationCreate);
                        }
                        else
                        {
                            ViewBag.ErrorMessage = responseMaisonMedicaleBis.Content.ReadAsAsync<string>().Result + " " + responseSpecialite.Content.ReadAsAsync<string>().Result + " " + responseMedecin.Content.ReadAsAsync<string>().Result;
                            ViewBag.Patient_ID = consultationCreate.Patient_ID;

                            return View("AddConsultationForPatient", consultationCreate);
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseMaisonMedicale.Content.ReadAsAsync<string>().Result + " " + responseConsultation.Content.ReadAsAsync<string>().Result;
                        ViewBag.Patient_ID = consultationCreate.Patient_ID;

                        return View("AddConsultationForPatient", consultationCreate);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("AddConsultationForPatient");
            }
        }

        public async Task<ActionResult> GetAllConsultationForPatient(int id)
        {
            try
            {
                ViewBag.ErrorMessage = "";
                ViewBag.Patient_ID = id;

                List<ModelView.ConsultationView> consultations = new List<ModelView.ConsultationView>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:44349");
                    HttpResponseMessage responseConsultation = await client.GetAsync("api/Consultation/GetAllConsultationForPatient/" + id);

                    if (responseConsultation.IsSuccessStatusCode)
                    {
                        foreach (var consultation in JsonConvert.DeserializeObject<List<Models.Consultation>>(responseConsultation.Content.ReadAsStringAsync().Result))
                        {
                            HttpResponseMessage responseMaisonMedicale = await client.GetAsync("api/MaisonMedicale//GetMaisonMedicaleFromMSMM/" + consultation.MedecinSpecialiteMaisonMedicale_ID);
                            HttpResponseMessage responseMedecin = await client.GetAsync("api/Medecin/GetMedecinFromMSMM/" + consultation.MedecinSpecialiteMaisonMedicale_ID);
                            HttpResponseMessage responseSpecialite = await client.GetAsync("api/Specialite/GetSpecialiteFromMSMM/" + consultation.MedecinSpecialiteMaisonMedicale_ID);
                            HttpResponseMessage responseLocal = await client.GetAsync("api/Local/" + consultation.Local_ID);

                            if (responseMaisonMedicale.IsSuccessStatusCode && responseMedecin.IsSuccessStatusCode && responseSpecialite.IsSuccessStatusCode && responseLocal.IsSuccessStatusCode)
                            {
                                consultations.Add(new ModelView.ConsultationView
                                {
                                    Consultation = consultation,
                                    MaisonMedicale = JsonConvert.DeserializeObject<Models.MaisonMedicale>(responseMaisonMedicale.Content.ReadAsStringAsync().Result),
                                    Medecin = JsonConvert.DeserializeObject<Models.Medecin>(responseMedecin.Content.ReadAsStringAsync().Result),
                                    Specialite = JsonConvert.DeserializeObject<Models.Specialite>(responseSpecialite.Content.ReadAsStringAsync().Result),
                                    Local = JsonConvert.DeserializeObject<Models.Local>(responseLocal.Content.ReadAsStringAsync().Result),
                                });
                            }
                            else
                            {
                                ViewBag.ErrorMessage = responseMaisonMedicale.Content.ReadAsAsync<string>().Result + " " + responseMedecin.Content.ReadAsAsync<string>().Result + " " + responseSpecialite.Content.ReadAsAsync<string>().Result + " " + responseLocal.Content.ReadAsAsync<string>().Result;
                                ViewBag.Patient_ID = id;
                            }
                        }
                        return View(consultations);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseConsultation.Content.ReadAsAsync<string>().Result;
                        ViewBag.Patient_ID = id;
                        return View(consultations);
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