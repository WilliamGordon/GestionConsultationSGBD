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
        // GET: Medecin
        public async Task<ActionResult> GetAllPatient()
        {
            List<Models.Patient> patients = new List<Models.Patient>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Patient");

                if (Res.IsSuccessStatusCode)
                {
                    var PatResponse = Res.Content.ReadAsStringAsync().Result;
                    patients = JsonConvert.DeserializeObject<List<Models.Patient>>(PatResponse);
                }
                return View(patients);
            }
        }

        public async Task<ActionResult> SelectPatients()
        {
            List<Models.Patient> patients = new List<Models.Patient>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Patient");

                if (Res.IsSuccessStatusCode)
                {
                    var PatResponse = Res.Content.ReadAsStringAsync().Result;
                    patients = JsonConvert.DeserializeObject<List<Models.Patient>>(PatResponse);
                }
                return View(patients);
            }
        }

        // GET: Medecin/AddMedecin
        public ActionResult AddPatient()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        // POST: Medecin/AddMedecin
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
                    var Res = await client.PostAsJsonAsync<Models.Patient>("api/Patient/", patient);

                    if (Res.IsSuccessStatusCode)
                    {
                        ViewBag.ErrorMessage = "";
                        return RedirectToAction("GetAllConsultationForPatient/" + Res.Content.ReadAsAsync<int>().Result);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = Res.Content.ReadAsAsync<string>().Result;
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetConsultationForPatient(int id)
        {
            ViewBag.Patient_ID = id;
            List<Models.Consultation> consultations = new List<Models.Consultation>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Consultation/GetAllConsultationForPatient/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var MedResponse = Res.Content.ReadAsStringAsync().Result;
                    consultations = JsonConvert.DeserializeObject<List<Models.Consultation>>(MedResponse);
                }
                return View(consultations);
            }
        }

        // GET: Medecin/AddMedecin
        public async Task<ActionResult> AddConsultationForPatient(int id)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Patient_ID = id;

            ModelView.ConsultationCreate consultationCreate = new ModelView.ConsultationCreate();
            List<Models.MaisonMedicale> MMs = new List<Models.MaisonMedicale>();

            consultationCreate.Patient_ID = id;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/MaisonMedicale");

                if (Res.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = "";
                    MMs = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(Res.Content.ReadAsStringAsync().Result);
                    consultationCreate.listMaisonMedicales = MMs;
                    return View(consultationCreate);
                }
                else
                {
                    ViewBag.ErrorMessage = Res.Content.ReadAsAsync<string>().Result;
                    return View(consultationCreate);
                }
            }
        }

        public async Task<ActionResult> GetAllConsultationForPatient(int id)
        {
            ViewBag.Patient_ID = id;
            List<ModelView.ConsultationView> consultations = new List<ModelView.ConsultationView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ResCons = await client.GetAsync("api/Consultation/GetAllConsultationForPatient/" + id);


                if (ResCons.IsSuccessStatusCode)
                {
                    var MedResponse = ResCons.Content.ReadAsStringAsync().Result;
                    consultations = JsonConvert.DeserializeObject<List<ModelView.ConsultationView>>(MedResponse);

                    foreach (var c in consultations)
                    {
                        HttpResponseMessage ResMM = await client.GetAsync("api/MaisonMedicale//GetMaisonMedicaleFromMSMM/" + c.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage ResMedecin = await client.GetAsync("api/Medecin/GetMedecinFromMSMM/" + c.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage ResSpec = await client.GetAsync("api/Specialite/GetSpecialiteFromMSMM/" + c.MedecinSpecialiteMaisonMedicale_ID);

                        if (ResMM.IsSuccessStatusCode && ResMedecin.IsSuccessStatusCode && ResSpec.IsSuccessStatusCode)
                        {
                            c.Medecin = JsonConvert.DeserializeObject<Models.Medecin>(ResMedecin.Content.ReadAsStringAsync().Result);
                            c.MaisonMedicale = JsonConvert.DeserializeObject<Models.MaisonMedicale>(ResMM.Content.ReadAsStringAsync().Result);
                            c.Specialite = JsonConvert.DeserializeObject<Models.Specialite>(ResSpec.Content.ReadAsStringAsync().Result);
                            c.MaisonMedicale_ID = c.MaisonMedicale.MaisonMedicale_ID;
                        }

                    }

                }
                return View(consultations);
            }
        }

    }
}