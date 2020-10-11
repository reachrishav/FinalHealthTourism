using FinalHealthTourism.Models;
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

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Patient p)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(p);
                db.SaveChanges();
            }
            return View("Success");
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
    }
}