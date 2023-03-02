using System;

namespace EventManagement.Domain {
    public interface IEvent {
        int EventId { get; set; }
        string Name { get; set; }
        DateTime EventDate { get; set; }
        bool IsActive { get; set; }
    }
}
