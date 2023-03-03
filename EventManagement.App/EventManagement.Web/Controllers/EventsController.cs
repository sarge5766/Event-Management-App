﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            if (Session["Username"] == null) {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Add() {
            return View();
        }
    }
}