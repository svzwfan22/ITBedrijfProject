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
    }
}