using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class DashboardController : BaseController {
        private readonly dynamic objects;
        public DashboardController() {
            ViewBag.Section = "dashboard";

            objects = new ExpandoObject();
            objects.Contacts = GetContacts();
            objects.Events = GetEvents();
        }

        // GET: Dashboard
        public ActionResult Index() {
            return View(objects);
        }

        private List<Contact> GetContacts() {
            var serviceUrl = @"api/Contacts/GetAll";

            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Contact>>(response.Content);
        }

        private List<Event> GetEvents() {
            var serviceUrl = @"api/Events/GetAll";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<Event>>(response.Content);
        }
    }
}