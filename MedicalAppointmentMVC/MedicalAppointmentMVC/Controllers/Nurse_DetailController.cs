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
    public class Nurse_DetailController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Nurse_Detail
        public async Task<ActionResult> Index()
        {
            return View(await db.Nurse_Details.ToListAsync());
        }

        // GET: Nurse_Detail/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse_Detail nurse_Detail = await db.Nurse_Details.FindAsync(id);
            if (nurse_Detail == null)
            {
                return HttpNotFound();
            }
            return View(nurse_Detail);
        }

        // GET: Nurse_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nurse_Detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nurse_id,first_name,surname,cellno,telno,address,post_code,med_practice_no")] Nurse_Detail nurse_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Nurse_Details.Add(nurse_Detail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nurse_Detail);
        }

        // GET: Nurse_Detail/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse_Detail nurse_Detail = await db.Nurse_Details.FindAsync(id);
            if (nurse_Detail == null)
            {
                return HttpNotFound();
            }
            return View(nurse_Detail);
        }

        // POST: Nurse_Detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "nurse_id,first_name,surname,cellno,telno,address,post_code,med_practice_no")] Nurse_Detail nurse_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurse_Detail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nurse_Detail);
        }

        // GET: Nurse_Detail/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse_Detail nurse_Detail = await db.Nurse_Details.FindAsync(id);
            if (nurse_Detail == null)
            {
                return HttpNotFound();
            }
            return View(nurse_Detail);
        }

        // POST: Nurse_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Nurse_Detail nurse_Detail = await db.Nurse_Details.FindAsync(id);
            db.Nurse_Details.Remove(nurse_Detail);
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
