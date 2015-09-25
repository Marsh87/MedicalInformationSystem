using MedicalAppointmentMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalAppointmentMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {


            var AdminName = "OperationsManager@medical.co.za";
            var password = "medical_services1234#";
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string roleName = "OperationsManager";
            IdentityResult roleResult;
            if (!RoleManager.RoleExists(roleName))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName));
            }
            var user = new ApplicationUser() { UserName = AdminName };
            var findUser = UserManager.FindByName(AdminName);
            if (findUser == null)
            {
                var result = await UserManager.CreateAsync(user, password);
                var getUser = UserManager.FindByName(AdminName);
                UserManager.AddToRole(getUser.Id, roleName);
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}