using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class ContactsController : BaseController {
        public ContactsController() {
            ViewBag.Section = "contacts";
        }

        public ActionResult Index() {
            return View(GetContacts());
        }

        public ActionResult Add() {
            return View();
        }

        public ActionResult AddContact(Contact contact) {
            var serviceUrl = @"api/Contacts/Create";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Contact {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MobileNumber = contact.MobileNumber,
                Address = contact.Address,
                City = contact.City,
                State = contact.State,
                Zipcode = contact.Zipcode,
                ReferredBy = contact.ReferredBy,
                BloodType = contact.BloodType
            });

            client.Execute(request);

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Delete(int id) {
            DeleteContact(id);

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Update(Contact contact) {
            var serviceUrl = @"api/Contacts/Update";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Contact {
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MobileNumber = contact.MobileNumber,
                Address = contact.Address,
                City = contact.City,
                State = contact.State,
                Zipcode = contact.Zipcode,
                ReferredBy = contact.ReferredBy,
                BloodType = contact.BloodType
            });

            client.Execute(request);
            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult UpdateContact(int id) {
            return View(GetById(id));
        }

        private void DeleteContact(int id) {
            var serviceUrl = $@"api/Contacts/Delete/{id}";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Delete);
            request.RequestFormat = DataFormat.Json;
            client.Execute(request);
        }

        private Contact GetById(int id) {
            var serviceUrl = $@"api/Contacts/GetById/{id}";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<Contact>(response.Content);
        }

        private List<Contact> GetContacts() {
            var serviceUrl = @"api/Contacts/GetAll";

            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Contact>>(response.Content);
        }
    }
}