using FinalHealthTourism.Models;
using FinalHealthTourism.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FinalHealthTourism.Controllers
{
    public class DoctorController : Controller
    {
        private static int p_id = 0;
        private MedicalTourismContext db;
        public DoctorController()
        {
            db = new MedicalTourismContext();
        }

        public ActionResult DoctorSignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorSignUp(Doctor d)
        {
            if (ModelState.IsValid)
            {
                d.FromDateTimeAvailable = DateTime.Now;
                d.ToDateTimeAvailable = DateTime.Now;
                d.Speciality = "NA";
                d.HospitalAssociated = "NA";
                db.Doctors.Add(d);
                db.SaveChanges();
                return View("Success");
            }
            else
            {
                return View();
            }
        }


        public ActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorLogin(Doctor d)
        {
            var doctor = db.Doctors.FirstOrDefault(m => m.Id == d.Id && m.Password == d.Password);
            if (doctor != null)
            {
                TempData["currentDoctor"] = doctor.FirstName;
                return View("DoctorDashboard", doctor);
            }
            else
            {
                ViewBag.Message = "Login Not Successful";
            }

            return View();
        }
        public ActionResult UpdateDetails(string id)
        {
            var doctor = db.Doctors.FirstOrDefault(m => m.Id == id);
            var hospitalAdmins = db.HospitalAdmins.Select(ha => ha.HospitalName).ToList();
            ViewBag.HospitalAdmins = hospitalAdmins;
            return View("UpdateDetails", doctor);
        }
        [HttpPost]
        public ActionResult UpdateDetails(Doctor d)
        {
            var doctor = db.Doctors.FirstOrDefault(x => x.Id == d.Id);
            var hospitalId = db.HospitalAdmins.Where(x => x.HospitalName == d.HospitalAssociated).Select(x => x.Id).Single();
            doctor.FromDateTimeAvailable = d.FromDateTimeAvailable;
            doctor.ToDateTimeAvailable = d.ToDateTimeAvailable;
            doctor.HospitalAssociated = d.HospitalAssociated;
            doctor.Speciality = d.Speciality;
            doctor.DateOfBirth = d.DateOfBirth;
            doctor.HospitalAdminId = hospitalId;
            db.SaveChanges();
            return View("UpdateSuccess");

        }

        public ActionResult MyAppointments(string id)
        {
            var appointments = db.Appointments.Include(x => x.Doctor).Include(x => x.Patient).Where(x => x.DoctorId == id).ToList();
            /*var patients = db.Patients.Where().ToList();*/
            /*var appointmentViewModel = new AppointmentViewModel
            {
                Appointments = appointments,
                Patients = patients,
            };*/
            return View(appointments);
        }
        [HttpPost]
        public string Approve(string id)
        {
            var appointmentToBeApproved = db.Appointments.Single(a => a.Id == id);
            appointmentToBeApproved.AppointmentApproved = true;
            db.SaveChanges();
            return "Approved";
        }

        public ActionResult PatientSchedule(string id)
        {
            var appointment = db.Appointments.Include(x => x.Doctor).Include(x => x.Patient).FirstOrDefault(x => x.Id == id);
            TempData["currentDoctorId"] = appointment.Doctor.Id;
            //TempData["currentDoctorDL"] = appointment.Doctor;
            TempData["currentPatientId"] = appointment.Patient.Id;
            //TempData["currentPatientDL"] = appointment.Patient;
            TempData["currentDoctorHospital"] = appointment.Doctor.HospitalAssociated;
            var TreatmentViewModel = new TreatmentViewModel
            {
                TreatmentRecord = new TreatmentRecord(),
                Patient = appointment.Patient
            };
            return View(TreatmentViewModel);
        }
        [HttpPost]
        public ActionResult PatientSchedule(TreatmentViewModel record)
        {
            p_id += 1;
            TreatmentRecord tr = new TreatmentRecord();
            tr.DoctorId = TempData["currentDoctorId"].ToString();
            tr.PatientId = TempData["currentPatientId"].ToString();
            tr.TreatmentPlanned = record.TreatmentRecord.TreatmentPlanned;
            tr.DiagnosisDetails = record.TreatmentRecord.DiagnosisDetails;
            tr.MedicinesPrescribed = record.TreatmentRecord.MedicinesPrescribed;
            tr.RevisitDate = record.TreatmentRecord.RevisitDate;
            string hospitalName = TempData["currentDoctorHospital"].ToString();
            /*record.DoctorId = TempData["currentDoctorId"].ToString();
            record.PatientId = TempData["currentPatientId"].ToString();*/
            tr.P_Id = hospitalName.Substring(0, 3).ToUpper() + p_id.ToString("0000");
            db.TreatmentRecords.Add(tr);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return View("AppointmentSuccess");
        }

        public ActionResult MyTreatmentRecords(string id)
        {
            var treatmentRecords = db.TreatmentRecords.Where(x => x.DoctorId == id).ToList();
            return View(treatmentRecords);
        }

        public ActionResult UpdateTreatment(string id)
        {
            var treatmentRecord = db.TreatmentRecords.FirstOrDefault(x => x.P_Id == id);
            var patient = db.Patients.FirstOrDefault(x => x.Id == treatmentRecord.PatientId);
            TempData["currentP_id"] = id;
            var treatmentViewModel = new TreatmentViewModel
            {
                Patient = patient,
                TreatmentRecord = treatmentRecord
            };
            return View(treatmentViewModel);
        }
        [HttpPost]
        public ActionResult UpdateTreatment(TreatmentViewModel record)
        {
            string currentTreatmentId = TempData["currentP_id"].ToString();
            var myTreatmentRecord =
                db.TreatmentRecords.FirstOrDefault(x => x.P_Id == currentTreatmentId);
            myTreatmentRecord.DiagnosisDetails = record.TreatmentRecord.DiagnosisDetails;
            myTreatmentRecord.TreatmentPlanned = record.TreatmentRecord.TreatmentPlanned;
            myTreatmentRecord.MedicinesPrescribed = record.TreatmentRecord.MedicinesPrescribed;
            myTreatmentRecord.RevisitDate = record.TreatmentRecord.RevisitDate;
            db.SaveChanges();
            return View("AppointmentSuccess");
        }
    }
}