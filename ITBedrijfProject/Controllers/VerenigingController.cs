using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using System;
using System.Collections;
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

        [HttpGet]
        public ActionResult Details(int id)
        {
            Organisation organisation = DAOrganisationRegister.GetOrganisationById(id);
            ViewBag.Organisation = organisation;
            ViewBag.Id = id;
            return View(organisation);
        }

        [HttpPost]
        public ActionResult Details()
        {
           
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Organisation organisation = DAOrganisationRegister.GetOrganisationById(id);
            ViewBag.Organisation = organisation;
            ViewBag.Id = id;
            return View(organisation);
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Login, string Password, string DbName, string DbLogin, string DbPassword, string OrganisationName, string Address, string Email, string Phone)
        {

            DAOrganisationRegister.UpdateOrganisation(Id, Login, Password, DbName, DbLogin, DbPassword, OrganisationName, Address, Email, Phone);
            return RedirectToAction("Index");


        }
    }
}