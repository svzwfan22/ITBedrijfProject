using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using ITBedrijfProject.PresentationModels;
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
            
                Organisation organisation = new Organisation();
                organisation.Login = Login;
                organisation.Password = Password;
                organisation.DbName = DbName;
                organisation.DbLogin = DbLogin;
                organisation.DbPassword = DbPassword;
                organisation.OrganisationName = OrganisationName;
                organisation.Address = Address;
                organisation.Email = Email;
                organisation.Phone = Phone;

                DAOrganisationRegister.InsertOrganisation(organisation);
           
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

        [HttpGet]
        public ActionResult Register(int id)
        {
            ViewBag.Register = DAOrganisationRegister.GetOrganisationRegisterById(id);
            ViewBag.Organisation = DAOrganisationRegister.GetOrganisationById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Register()
        {

            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult NewRegister(int id)
        {
            PMOrganisationRegister organisationRegister = new PMOrganisationRegister();
            organisationRegister.NewRegister = new MultiSelectList(DAOrganisationRegister.GetRegisters(), "Id", "RegisterName", "Device");
            organisationRegister.OrganisationID = id;
            ViewBag.Organisation = DAOrganisationRegister.GetOrganisationById(id);
            return View(organisationRegister);
        }

        [HttpPost]
        public ActionResult NewRegister(int organisationID, int registerID, DateTime FromDate, DateTime FromTime, DateTime UntilDate, DateTime UntilTime)
        {
            if (FromDate >= UntilDate) return RedirectToAction("Register", new { id = organisationID });
            OrganisationRegister organisationRegister = new OrganisationRegister();
            organisationRegister.OrganisationID = organisationID;
            organisationRegister.RegisterID = registerID;
            organisationRegister.FromDate = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, FromTime.Hour, FromTime.Minute, 0);
            organisationRegister.UntilDate = new DateTime(UntilDate.Year, UntilDate.Month, UntilDate.Day, UntilTime.Hour, UntilTime.Minute, 0);

            DAOrganisationRegister.InsertOrganisationRegister(organisationRegister);
            return RedirectToAction("Register", new { id = organisationID });
        }

        [HttpGet]
        public ActionResult EditRegister(int organisationID, int registerID)
        {
            PMOrganisationRegister organisationRegister = new PMOrganisationRegister();
            organisationRegister.NewOrganisation = new MultiSelectList(DAOrganisationRegister.GetOrganisations(), "Id", "OrganisationName");
            OrganisationRegister or = DAOrganisationRegister.GetOrganisationRegisterByIds(organisationID, registerID);
            organisationRegister.Device = or.Device;
            organisationRegister.FromDate = or.FromDate;
            organisationRegister.Login = or.Login;
            organisationRegister.OrganisationID = or.OrganisationID;
            organisationRegister.OrganisationName = or.OrganisationName;
            organisationRegister.RegisterID = or.RegisterID;
            organisationRegister.RegisterName = or.RegisterName;
            organisationRegister.UntilDate = or.UntilDate;

            ViewBag.Organisation = DAOrganisationRegister.GetOrganisationById(organisationID);
            ViewBag.oldId = organisationID;
            return View(organisationRegister);
        }

        [HttpPost]
        public ActionResult EditRegister(int oldOrganisationID, int organisationID, DateTime fromDate, DateTime untilDate, int registerID)
        {
            OrganisationRegister organisationRegister = DAOrganisationRegister.GetOrganisationRegisterByIds(organisationID, registerID);
            organisationRegister.FromDate = fromDate;
            organisationRegister.OrganisationID = organisationID;
            organisationRegister.RegisterID = registerID;
            organisationRegister.UntilDate = untilDate;
            DAOrganisationRegister.UpdateOrganisationRegister(oldOrganisationID, organisationRegister);
            return RedirectToAction("Register", new { id = oldOrganisationID });
        }
    
    }
}