using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijfProject.Controllers
{
    public class KassaController : Controller
    {
        // GET: Kassa
        public ActionResult Index()
        {
            List<Register> registers = DAOrganisationRegister.GetRegisters();
            ViewBag.Registers = registers;
            return View();
        }

        [HttpGet]
        public ActionResult NewRegister()
        {
            //var context = new ApplicationDbContext();
            //ViewBag.Users = context.Users;
            return View();
        }

        [HttpPost]
        public ActionResult NewRegister(string RegisterName, string Device, DateTime PurchaseDate, DateTime ExpiresDate)
        {
            DAOrganisationRegister.InsertRegister(RegisterName, Device, PurchaseDate, ExpiresDate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Register register = DAOrganisationRegister.GetRegisterById(id);
            ViewBag.Register = register;
            ViewBag.Id = id;
            return View(register);
        }

        [HttpPost]
        public ActionResult Details()
        {

            return View("Index");
        }

        [HttpGet]
        public ActionResult Logs(int id)
        {
           // Register register = DAOrganisationRegister.GetRegisterById(id);
            // ViewBag.Register = register;
            // ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Logs()
        {

            return View("Index");
        }
    }
}