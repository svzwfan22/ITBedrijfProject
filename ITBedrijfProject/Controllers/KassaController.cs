using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using ITBedrijfProject.PresentationModels;
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
            List<Register> registers = DARegister.GetRegisters();
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
        public ActionResult NewRegister(PMRegister register)
        {
            if (ModelState.IsValid)
            {
                if (register.PurchaseDate >= register.ExpiresDate) return View(register);
                DARegister.InsertRegister(register);
                return RedirectToAction("Index");
            }
            return View(register);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Register register = DARegister.GetRegisterById(id);
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
            Register register = DARegister.GetRegisterById(id);
            ViewBag.Register = register;

           List<Errorlog> log = DAErrorLog.GetLogsById(id);
             ViewBag.Log = log;
             ViewBag.Id = id;
             return View();
        }

        [HttpPost]
        public ActionResult Logs()
        {

            return View("Index");
        }
    }
}