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
    public class Patient_DetailController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Patient_Detail
        public async Task<ActionResult> Index()
        {
            return View(await db.Patient_Details.ToListAsync());
        }

        // GET: Patient_Detail/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Detail patient_Detail = await db.Patient_Details.FindAsync(id);
            if (patient_Detail == null)
            {
                return HttpNotFound();
            }
            return View(patient_Detail);
        }

        // GET: Patient_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient_Detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "patient_id,first_name,surname,cellno,telno,address,post_code,med_aid_no,med_aid_dep_no")] Patient_Detail patient_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Patient_Details.Add(patient_Detail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(patient_Detail);
        }

        // GET: Patient_Detail/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Detail patient_Detail = await db.Patient_Details.FindAsync(id);
            if (patient_Detail == null)
            {
                return HttpNotFound();
            }
            return View(patient_Detail);
        }

        // POST: Patient_Detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "patient_id,first_name,surname,cellno,telno,address,post_code,med_aid_no,med_aid_dep_no")] Patient_Detail patient_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Detail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patient_Detail);
        }

        // GET: Patient_Detail/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Detail patient_Detail = await db.Patient_Details.FindAsync(id);
            if (patient_Detail == null)
            {
                return HttpNotFound();
            }
            return View(patient_Detail);
        }

        // POST: Patient_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patient_Detail patient_Detail = await db.Patient_Details.FindAsync(id);
            db.Patient_Details.Remove(patient_Detail);
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
