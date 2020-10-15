using FinalHealthTourism.Models;
using FinalHealthTourism.ViewModels;
using Rotativa;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FinalHealthTourism.Controllers
{
    public class PatientController : Controller
    {
        private MedicalTourismContext db;

        public PatientController()
        {
            db = new MedicalTourismContext();
        }
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PatientSignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientSignUp(Patient p)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(p);
                db.SaveChanges();
                return View("Success");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DisplayPatients()
        {
            return View(db.Patients.ToList());
        }
        [HttpPost]
        public string Delete(string id)
        {
            var selectedPatient = db.Patients.FirstOrDefault(x => x.Id == id);
            db.Patients.Remove(selectedPatient);
            db.SaveChanges();
            return "Successfully deleted";
        }

        public ActionResult PatientLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientLogin(Patient p)
        {
            var patient = db.Patients.FirstOrDefault(m => m.Id == p.Id && m.Password == p.Password);
            var doctors = db.Doctors.Include(d => d.HospitalAdmin).ToList();
            if (patient != null)
            {
                TempData["currentPatient"] = patient.FirstName;
                TempData["currentPatientId"] = patient.Id;
                return View("PatientDashboard", doctors);
            }
            else
            {
                ViewBag.Message = "Username or Password is incorrect";
            }

            return View();
        }

        public ActionResult Appointment(string dId, string pId)
        {
            var newAppointment = new Appointment
            {
                DoctorId = dId,
                PatientId = pId,
                AppointmentApproved = false,
                Id = dId.ToUpper() + pId.ToUpper()
            };
            db.Appointments.Add(newAppointment);
            db.SaveChanges();
            return View("AppointmentSuccess");
        }

        public ActionResult MyTreatment(string id)
        {
            var treatmentRecord = db.TreatmentRecords.FirstOrDefault(x => x.PatientId == id);
            if (treatmentRecord == null)
            {
                return View("NotYetGiven");
            }
            var doctor = db.Doctors.FirstOrDefault(x => x.Id == treatmentRecord.DoctorId);
            var patient = db.Patients.FirstOrDefault(x => x.Id == id);
            var showTreatmentViewModel = new ShowTreatmentRecordViewModel
            {
                Doctor = doctor,
                TreatmentRecord = treatmentRecord,
                Patient = patient
            };

            return View(showTreatmentViewModel);
        }

        public ActionResult ExportAsPdf(string pId)
        {
            ActionAsPdf result = new ActionAsPdf("MyTreatment", new { id = pId })
            {
                FileName = Server.MapPath("~/Content/Report.pdf")
            };
            return result;
        }
    }
}