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

        // GET: Medecin/AddMedecin
        public async Task<ActionResult> EditConsultation(int id)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Patient_ID = id;

            ModelView.ConsultationCreate consultationCreate = new ModelView.ConsultationCreate();
            List<Models.MaisonMedicale> MMs = new List<Models.MaisonMedicale>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ResMM = await client.GetAsync("api/MaisonMedicale");
                HttpResponseMessage ResCons = await client.GetAsync("api/Consultation/" + id);

                if (ResMM.IsSuccessStatusCode && ResCons.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = "";
                    MMs = JsonConvert.DeserializeObject<List<Models.MaisonMedicale>>(ResMM.Content.ReadAsStringAsync().Result);
                    consultationCreate = JsonConvert.DeserializeObject<ModelView.ConsultationCreate>(ResCons.Content.ReadAsStringAsync().Result);
                    consultationCreate.listMaisonMedicales = MMs;
                    ViewBag.Patient_ID = consultationCreate.Patient_ID;

                    HttpResponseMessage ResMMbis = await client.GetAsync("api/MaisonMedicale//GetMaisonMedicaleFromMSMM/" + consultationCreate.MedecinSpecialiteMaisonMedicale_ID);
                    HttpResponseMessage ResSpec = await client.GetAsync("api/Specialite/GetSpecialiteFromMSMM/" + consultationCreate.MedecinSpecialiteMaisonMedicale_ID);
                    HttpResponseMessage ResMed = await client.GetAsync("api/Medecin/GetMedecinFromMSMM/" + consultationCreate.MedecinSpecialiteMaisonMedicale_ID);

                    if (ResMMbis.IsSuccessStatusCode && ResSpec.IsSuccessStatusCode && ResMed.IsSuccessStatusCode)
                    {
                        var MM = JsonConvert.DeserializeObject<Models.MaisonMedicale>(ResMMbis.Content.ReadAsStringAsync().Result);
                        var SP = JsonConvert.DeserializeObject<Models.Specialite>(ResSpec.Content.ReadAsStringAsync().Result);
                        var MD = JsonConvert.DeserializeObject<Models.Medecin>(ResMed.Content.ReadAsStringAsync().Result);

                        consultationCreate.MaisonMedicale_ID = MM.MaisonMedicale_ID;
                        consultationCreate.Specialite_ID = SP.Specialite_ID;
                        consultationCreate.Medecin_ID = MD.Medecin_ID;

                        return View("AddConsultationForPatient", consultationCreate);
                    }
                    else
                    {
                        return View("AddConsultationForPatient", consultationCreate);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = ResMM.Content.ReadAsAsync<string>().Result;

                    ViewBag.Patient_ID = consultationCreate.Patient_ID;

                    return View("AddConsultationForPatient", consultationCreate);
                }
            }
        }
        

        public async Task<ActionResult> GetAllConsultationForPatient(int id)
        {
            ViewBag.Patient_ID = id;
            List<ModelView.ConsultationView> consultations = new List<ModelView.ConsultationView>();
            List<Models.Consultation> cons = new List<Models.Consultation>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ResCons = await client.GetAsync("api/Consultation/GetAllConsultationForPatient/" + id);


                if (ResCons.IsSuccessStatusCode)
                {
                    var MedResponse = ResCons.Content.ReadAsStringAsync().Result;
                    cons = JsonConvert.DeserializeObject <List< Models.Consultation >>(MedResponse);

                    foreach (var c in cons)
                    {
                        HttpResponseMessage ResMM = await client.GetAsync("api/MaisonMedicale//GetMaisonMedicaleFromMSMM/" + c.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage ResMedecin = await client.GetAsync("api/Medecin/GetMedecinFromMSMM/" + c.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage ResSpec = await client.GetAsync("api/Specialite/GetSpecialiteFromMSMM/" + c.MedecinSpecialiteMaisonMedicale_ID);
                        HttpResponseMessage ResLocal = await client.GetAsync("api/Local/" + c.Local_ID);

                        if (ResMM.IsSuccessStatusCode && ResMedecin.IsSuccessStatusCode && ResSpec.IsSuccessStatusCode && ResLocal.IsSuccessStatusCode)
                        {
                            var cView = new ModelView.ConsultationView();
                            cView.Consultation = c;
                            cView.Medecin = JsonConvert.DeserializeObject<Models.Medecin>(ResMedecin.Content.ReadAsStringAsync().Result);
                            cView.MaisonMedicale = JsonConvert.DeserializeObject<Models.MaisonMedicale>(ResMM.Content.ReadAsStringAsync().Result);
                            cView.Specialite = JsonConvert.DeserializeObject<Models.Specialite>(ResSpec.Content.ReadAsStringAsync().Result);
                            cView.Local = JsonConvert.DeserializeObject<Models.Local>(ResLocal.Content.ReadAsStringAsync().Result);
                            consultations.Add(cView);
                        }

                    }

                }
                return View(consultations);
            }
        }

    }
}