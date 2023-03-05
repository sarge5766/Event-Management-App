using EventManagement.Domain;
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
      
        public override void Update(Contact contact) {
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
        }
    }
}