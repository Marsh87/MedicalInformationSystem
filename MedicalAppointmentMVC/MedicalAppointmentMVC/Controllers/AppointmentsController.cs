using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalAppointmentMVC.Models;

namespace MedicalAppointmentMVC.Controllers
{
    [Authorize(Roles = "Nurse")]
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private MedicalContext db = new MedicalContext();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Doctor_Detail).Include(a => a.Patient_Detail);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.doctor_id = new SelectList(db.Doctor_Details, "doctor_id", "first_name");
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "app_id,patient_id,doctor_id,start_date_time,end_date_time")] Appointment appointment)
        {

            if (appointment.patient_id == 0)
            {
                ModelState.AddModelError("pleaseselectpatient", "Please select patient");
            }
            if (appointment.doctor_id == 0)
            {
                ModelState.AddModelError("pleaseselectdoctor", "Please select Doctor");
            }

            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctor_id = new SelectList(db.Doctor_Details, "doctor_id", "first_name", appointment.doctor_id);
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name", appointment.patient_id);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctor_id = new SelectList(db.Doctor_Details, "doctor_id", "first_name", appointment.doctor_id);
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name", appointment.patient_id);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "app_id,patient_id,doctor_id,start_date_time,end_date_time")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctor_id = new SelectList(db.Doctor_Details, "doctor_id", "first_name", appointment.doctor_id);
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name", appointment.patient_id);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
