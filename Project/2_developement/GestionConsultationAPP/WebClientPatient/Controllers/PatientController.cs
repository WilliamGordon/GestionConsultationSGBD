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
                        return RedirectToAction("GetConsultationForPatient/" + Res.Content.ReadAsAsync<int>().Result);
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
    }
}