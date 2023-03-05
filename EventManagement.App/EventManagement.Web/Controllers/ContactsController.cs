using EventManagement.Domain;
using System.Dynamic;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class ContactsController : BaseController {
        readonly ContactRepository contactsRepository;
        readonly EventRepository eventsRepository;
        readonly dynamic objects;

        public ContactsController() {
            ViewBag.Section = "contacts";
            contactsRepository = new ContactRepository();
            eventsRepository = new EventRepository();
            objects = new ExpandoObject();
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
            objects.Contact = contactsRepository.GetById(id, $@"api/Contacts/GetById/{id}");
            objects.Events = eventsRepository.GetAll(@"api/Events/GetAll");

            return View(objects);
        }
    }
}