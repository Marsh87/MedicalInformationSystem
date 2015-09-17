using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalAppointmentMVC.Models;

namespace MedicalAppointmentMVC.Controllers
{
    public class Patient_Medical_HistoryController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Patient_Medical_History
        public async Task<ActionResult> Index()
        {
            var patients_Medical_History = db.Patients_Medical_History.Include(p => p.Patient_Detail);
            return View(await patients_Medical_History.ToListAsync());
        }

        // GET: Patient_Medical_History/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Medical_History patient_Medical_History = await db.Patients_Medical_History.FindAsync(id);
            if (patient_Medical_History == null)
            {
                return HttpNotFound();
            }
            return View(patient_Medical_History);
        }

        // GET: Patient_Medical_History/Create
        public ActionResult Create()
        {
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name");
            return View();
        }

        // POST: Patient_Medical_History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "med_hist_id,patient_id,diagnosis,blood_sugar_level,cholesterol_rating,blood_pressure,recommendation")] Patient_Medical_History patient_Medical_History)
        {
            if (ModelState.IsValid)
            {
                db.Patients_Medical_History.Add(patient_Medical_History);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name", patient_Medical_History.patient_id);
            return View(patient_Medical_History);
        }

        // GET: Patient_Medical_History/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Medical_History patient_Medical_History = await db.Patients_Medical_History.FindAsync(id);
            if (patient_Medical_History == null)
            {
                return HttpNotFound();
            }
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name", patient_Medical_History.patient_id);
            return View(patient_Medical_History);
        }

        // POST: Patient_Medical_History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "med_hist_id,patient_id,diagnosis,blood_sugar_level,cholesterol_rating,blood_pressure,recommendation")] Patient_Medical_History patient_Medical_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Medical_History).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.patient_id = new SelectList(db.Patient_Details, "patient_id", "first_name", patient_Medical_History.patient_id);
            return View(patient_Medical_History);
        }

        // GET: Patient_Medical_History/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Medical_History patient_Medical_History = await db.Patients_Medical_History.FindAsync(id);
            if (patient_Medical_History == null)
            {
                return HttpNotFound();
            }
            return View(patient_Medical_History);
        }

        // POST: Patient_Medical_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patient_Medical_History patient_Medical_History = await db.Patients_Medical_History.FindAsync(id);
            db.Patients_Medical_History.Remove(patient_Medical_History);
            await db.SaveChangesAsync();
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
