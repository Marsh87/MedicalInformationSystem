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
    [Authorize(Roles = "OperationsManager")]
    public class Doctor_DetailController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
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
        public async Task<ActionResult> Create(DoctorViewModel DoctorViewModel)
        {
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var user = new ApplicationUser() { UserName = DoctorViewModel.Email };
                var result = await UserManager.CreateAsync(user, DoctorViewModel.Password);
                string roleName = "Doctor";
                IdentityResult roleResult;
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
                try
                {
                    var findUser = UserManager.FindByName(DoctorViewModel.Email);
                    UserManager.AddToRole(findUser.Id, "Doctor");
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
                Doctor_Detail doctor = MapDoctor(DoctorViewModel);
                db.Doctor_Details.Add(doctor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(DoctorViewModel);
        }

        private static Doctor_Detail MapDoctor(DoctorViewModel DoctorViewModel)
        {
            var doctor = new Doctor_Detail();
            doctor.address = DoctorViewModel.address;
            doctor.cellno = DoctorViewModel.cellno;
            doctor.first_name = DoctorViewModel.first_name;
            doctor.med_practice_no = DoctorViewModel.med_practice_no;
            doctor.post_code = DoctorViewModel.post_code;
            doctor.specialization = DoctorViewModel.specialization;
            doctor.surname = DoctorViewModel.surname;
            doctor.telno = DoctorViewModel.telno;
            doctor.Email = DoctorViewModel.Email;
            return doctor;
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
