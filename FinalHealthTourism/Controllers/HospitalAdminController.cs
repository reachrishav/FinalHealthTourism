using FinalHealthTourism.Models;
using System.Linq;
using System.Web.Mvc;

namespace FinalHealthTourism.Controllers
{
    public class HospitalAdminController : Controller
    {
        private MedicalTourismContext db;

        public HospitalAdminController()
        {
            db = new MedicalTourismContext();
        }
        public ActionResult HospitalAdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HospitalAdminLogin(HospitalAdmin ha)
        {
            var admin = db.HospitalAdmins.FirstOrDefault(m => m.Id == ha.Id && m.Password == ha.Password);

            if (admin != null)
            {
                var doctorsInHospital = db.Doctors.Where(d => d.HospitalAssociated == admin.HospitalName).ToList();
                TempData["currentHospitalAdmin"] = admin.HospitalName;
                return View("HospitalAdminDashboard", doctorsInHospital);
            }
            else
            {
                ViewBag.Message = "Username or Password is Incorrect";
                return View();
            }

        }

        public ActionResult HospitalAdminSignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HospitalAdminSignUp(HospitalAdmin ha)
        {
            if (ModelState.IsValid)
            {
                ha.IsApproved = false;
                db.HospitalAdmins.Add(ha);
                db.SaveChanges();
                return View("Success");
            }

            return View();
        }
        [HttpPost]
        public string Approve(string id)
        {
            var HAdminToBeApproved = db.HospitalAdmins.Single(ha => ha.Id == id);
            HAdminToBeApproved.IsApproved = true;
            db.SaveChanges();
            return "Approved";
        }
        [HttpPost]
        public string Reject(string id)
        {
            var HAdminToBeApproved = db.HospitalAdmins.Single(ha => ha.Id == id);
            HAdminToBeApproved.IsApproved = false;
            db.SaveChanges();
            return "Approved";
        }

        public ActionResult UpdateSchedule(string id)
        {
            var doctor = db.Doctors.FirstOrDefault(x => x.Id == id);
            return View(doctor);
        }
        [HttpPost]
        public ActionResult UpdateSchedule(Doctor d)
        {
            var doctor = db.Doctors.FirstOrDefault(x => x.Id == d.Id);
            doctor.FromDateTimeAvailable = d.FromDateTimeAvailable;
            doctor.ToDateTimeAvailable = d.ToDateTimeAvailable;
            db.SaveChanges();
            return View("UpdateSuccessful");
        }
    }
}