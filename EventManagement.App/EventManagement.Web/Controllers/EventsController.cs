using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class EventsController : BaseController {
        readonly EventRepository repository;

        public EventsController() {
            ViewBag.Section = "events";
            repository = new EventRepository();
        }

        public ActionResult Index() {
            return View(repository.GetAll(@"api/Events/GetAll"));
        }

        public ActionResult Add() {
            return View();
        }

        public ActionResult AddEvent(Event @event) {
            repository.Add(@event);

            return RedirectToAction("Index", "Events");
        }

        public ActionResult Delete(int id) {
            repository.Delete(id, $@"api/Events/Delete/{id}");

            return RedirectToAction("Index", "Events");
        }

        public ActionResult Update(Event @event) {
            repository.Update(@event);

            return RedirectToAction("Index", "Events");
        }

        public ActionResult UpdateEvent(int id) {
            return View(repository.GetById(id, $@"api/Events/GetById/{id}"));
        }
    }
}