using System;

namespace EventManagement.Domain {
    public class Event : IEvent {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsActive { get; set; }
    }
}
