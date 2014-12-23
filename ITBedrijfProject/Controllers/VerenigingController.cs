using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijfProject.Controllers
{
    public class VerenigingController : Controller
    {
        // GET: Vereniging
        public ActionResult Index()
        {
            List<Organisation> organisations = DAOrganisationRegister.GetOrganisations();

            ViewBag.Organisations = organisations;

            return View();
        }

        [HttpGet]
        public ActionResult NewOrganisation()
        {
            //var context = new ApplicationDbContext();
            //ViewBag.Users = context.Users;
            return View();
        }

        [HttpPost]
        public ActionResult NewOrganisation(string Login, string Password, string DbName, string DbLogin, string DbPassword, string OrganisationName, string Address, string Email, string Phone)
        {
            DAOrganisationRegister.InsertOrganisation(Login,Password,DbName,DbLogin,DbPassword,OrganisationName,Address,Email,Phone);
            return RedirectToAction("Index");
        }
    }
}