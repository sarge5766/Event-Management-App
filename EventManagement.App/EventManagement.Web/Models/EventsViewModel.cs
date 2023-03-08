using EventManagement.Domain;
using System.Collections.Generic;

namespace EventManagement.Web {
    public class EventsViewModel {
        List<Event> @event { get; set; } = new List<Event>();
    }
}