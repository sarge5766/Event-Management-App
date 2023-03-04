using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class EventsController : BaseController {
       // private string _baseUrl = @"https://localhost:44331/";

        // GET: Events
        public ActionResult Index() {
            return View(GetEvents());
        }

        public ActionResult Add() {
            return View();
        }

        public ActionResult AddEvent(Event e) {
            var serviceUrl = @"api/Events/Create";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Event {
                Name = e.Name,
                EventDate = e.EventDate,
                IsActive = e.IsActive
            });

            client.Execute(request);

            return RedirectToAction("Index", "Events");
        }

        public ActionResult Delete(int id) {
            DeleteEvent(id);

            return RedirectToAction("Index", "Events");
        }

        public ActionResult Update(Event @event) {
            var serviceUrl = @"api/Events/Update";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Event {
                EventId = @event.EventId,
                Name = @event.Name,
                EventDate = @event.EventDate,
                IsActive = @event.IsActive
            });

            client.Execute(request);
            return RedirectToAction("Index", "Events");
        }

        public ActionResult UpdateEvent(int id) {
            return View(GetById(id));
        }

        private void DeleteEvent(int id) {
            var serviceUrl = $@"api/Events/Delete/{id}";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Delete);
            request.RequestFormat = DataFormat.Json;
            client.Execute(request);
        }

        private Event GetById(int id) {
            var serviceUrl = $@"api/Events/GetById/{id}";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var @event = JsonConvert.DeserializeObject<Event>(response.Content);

            return @event;
        }

        private List<Event> GetEvents() {
            var serviceUrl = @"api/Events/GetAll";

            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<List<Event>>(response.Content);

            return content;
        }
    }
}