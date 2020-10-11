using FinalHealthTourism.Models;
using System.Linq;
using System.Web.Mvc;

namespace FinalHealthTourism.Controllers
{
    public class AdminController : Controller
    {
        private MedicalTourismContext db;
        public AdminController()
        {
            db = new MedicalTourismContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            var admin = db.Admins.FirstOrDefault(m => m.Id == a.Id && m.Password == a.Password);
            if (admin != null)
            {
                ViewBag.Message = "Login Successful";
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ViewBag.Message = "Login Not Successful";
            }
            return View();
        }

        public ActionResult AdminDashboard()
        {
            return RedirectToAction("DisplayPatients", "Patient");
            /*return View("AdminDashboard");*/
        }
    }
}