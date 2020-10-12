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
                TempData["currentHospitalAdmin"] = admin.Id;
                return View("HospitalAdminDashboard");
            }
            else
            {
                ViewBag.Message = "Login Not Successful";
            }

            return View();
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
            }
            return View("Success");
        }
        [HttpPost]
        public string Approve(string id)
        {
            var HAdminToBeApproved = db.HospitalAdmins.Single(ha => ha.Id == id);
            HAdminToBeApproved.IsApproved = true;
            db.SaveChanges();
            return "Approved";
        }
    }
}