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
    public class Doctor_DetailController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Doctor_Detail
        public async Task<ActionResult> Index()
        {
            return View(await db.Doctor_Details.ToListAsync());
        }

        // GET: Doctor_Detail/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_Detail doctor_Detail = await db.Doctor_Details.FindAsync(id);
            if (doctor_Detail == null)
            {
                return HttpNotFound();
            }
            return View(doctor_Detail);
        }

        // GET: Doctor_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor_Detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "doctor_id,first_name,surname,cellno,telno,address,post_code,med_practice_no,specialization")] Doctor_Detail doctor_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Doctor_Details.Add(doctor_Detail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(doctor_Detail);
        }

        // GET: Doctor_Detail/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_Detail doctor_Detail = await db.Doctor_Details.FindAsync(id);
            if (doctor_Detail == null)
            {
                return HttpNotFound();
            }
            return View(doctor_Detail);
        }

        // POST: Doctor_Detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "doctor_id,first_name,surname,cellno,telno,address,post_code,med_practice_no,specialization")] Doctor_Detail doctor_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor_Detail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(doctor_Detail);
        }

        // GET: Doctor_Detail/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_Detail doctor_Detail = await db.Doctor_Details.FindAsync(id);
            if (doctor_Detail == null)
            {
                return HttpNotFound();
            }
            return View(doctor_Detail);
        }

        // POST: Doctor_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Doctor_Detail doctor_Detail = await db.Doctor_Details.FindAsync(id);
            db.Doctor_Details.Remove(doctor_Detail);
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
