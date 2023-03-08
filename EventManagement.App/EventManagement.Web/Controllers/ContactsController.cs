using EventManagement.Domain;
using System;
using System.Dynamic;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class ContactsController : BaseController {
        ContactRepository contactsRepository;
        readonly EventRepository eventsRepository;

        public ContactsController() {
            ViewBag.Section = "contacts";
            contactsRepository = new ContactRepository();
            eventsRepository = new EventRepository();
        }

        public ActionResult Index() {
            return View(contactsRepository.GetAll(@"api/Contacts/GetAll"));
        }

        public ActionResult Add() {
            return View();
        }

        public ActionResult AddContact(Contact contact) {
            contactsRepository.Add(contact);

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult AddEvent(int contactId) {
            Contact contact = contactsRepository.GetById(contactId, $@"api/Contacts/GetById/{contactId}");
            ViewBag.ContactId = contactId;
            ViewBag.FirstName = contact.FirstName;
            ViewBag.LastName = contact.LastName;

            return View(eventsRepository.GetAll(@"api/Events/GetAll"));
        }

        public ActionResult Delete(int id) {
            contactsRepository.Delete(id, $@"api/Contacts/Delete/{id}");

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Update(Contact contact) {
            contactsRepository.Update(contact);

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult UpdateContact(int id) {
            return View(contactsRepository.GetById(id, $@"api/Contacts/GetById/{id}"));
        }

        public ActionResult ViewDetails(int id) {
            Contact contact = contactsRepository.GetById(id, $@"api/Contacts/GetById/{id}");

            return View(contact);
        }

        public ActionResult AddEventToContact(Event @event) {
            var contactId = Request["contactId"];
            var eventId = @event.EventId;

            contactsRepository.AddEventToContact(Convert.ToInt32(Request["contactId"]) , @event.EventId);

            return RedirectToAction("Index");
        }

    }
}