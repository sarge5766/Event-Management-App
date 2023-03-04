using EventManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add() {
            var enumData = from BloodType b in Enum.GetValues(typeof(BloodType))
                           select new {
                               ID = (int)b,
                               Name = b.ToString()
                           };
            ViewBag.BloodType = enumData; 

            return View();
        }
    }
}