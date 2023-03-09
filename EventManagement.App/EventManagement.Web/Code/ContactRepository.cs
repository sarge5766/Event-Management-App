using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;

namespace EventManagement.Web {
    public class ContactRepository : GenericRepository<Contact> {
        public override void Add(Contact contact) {
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
        }
       
        public void RemoveEventFromContact(int contact, int eventId) {
            // TODO
        }

        public override void Update(Contact contact) {
            var serviceUrl = @"api/Contacts/Update";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
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
        }

        public void AddEventToContact(int contactId, int eventId) {
            var serviceUrl = $@"api/Contacts/AddContactEvent/{contactId}/{eventId}";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
            request.RequestFormat = DataFormat.Json;
           
            client.Execute(request);
        }
    }
}