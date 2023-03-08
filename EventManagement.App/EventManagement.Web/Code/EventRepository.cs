using EventManagement.Domain;
using RestSharp;
using System.Collections.Generic;

namespace EventManagement.Web {
    public class EventRepository : GenericRepository<Event> {
        public override void Add(Event @event) {
            var serviceUrl = @"api/Events/Create";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Event {
                Name = @event.Name,
                EventDate = @event.EventDate,
                IsActive = @event.IsActive
            });

            client.Execute(request);
        }
       
        public override void Update(Event @event) {
            var serviceUrl = @"api/Events/Update";
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Event {
               EventId = @event.EventId,
               EventDate= @event.EventDate,
               Name = @event.Name,
               IsActive = @event.IsActive
            });

            client.Execute(request);
        }
    }
}