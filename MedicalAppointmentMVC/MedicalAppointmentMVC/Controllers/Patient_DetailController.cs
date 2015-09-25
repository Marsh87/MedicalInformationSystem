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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MedicalAppointmentMVC.Controllers
{
    [Authorize(Roles = "Nurse")]
    public class Patient_DetailController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
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
        public async Task<ActionResult> Create(PatientViewModel PatientViewModel)
        {
            
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var user = new ApplicationUser() { UserName = PatientViewModel.Email };
                var result = await UserManager.CreateAsync(user, PatientViewModel.Password);
                string roleName = "Patient";
                IdentityResult roleResult;
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
                try
                {
                    var findUser = UserManager.FindByName(PatientViewModel.Email);
                    UserManager.AddToRole(findUser.Id, "Patient");
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }

                var patient = new Patient_Detail();
                patient.address = PatientViewModel.address;
                patient.cellno = PatientViewModel.cellno;
                patient.first_name = PatientViewModel.first_name;
                patient.med_aid_dep_no = PatientViewModel.med_aid_dep_no;
                patient.med_aid_no = PatientViewModel.med_aid_no;
                patient.post_code = PatientViewModel.post_code;
                patient.surname = PatientViewModel.surname;
                patient.telno = PatientViewModel.telno;

                db.Patient_Details.Add(patient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(PatientViewModel);
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
