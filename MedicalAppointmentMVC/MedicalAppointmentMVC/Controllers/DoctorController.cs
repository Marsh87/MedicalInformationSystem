using MedicalAppointmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalAppointmentMVC.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        // GET: Doctor
        private MedicalContext db = new MedicalContext();
        public ActionResult MyAppointments()
        {
            var userName = HttpContext.User.Identity.Name;

            var doctor = db.Doctor_Details.FirstOrDefault(x => x.Email == userName);

            var appointments = db.Appointments.AsQueryable().Where(a => a.doctor_id == doctor.doctor_id);
            return View(appointments.ToList());
        }
    }
}