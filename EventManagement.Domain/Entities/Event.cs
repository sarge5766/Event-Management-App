using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain {
    public class Event : IEvent {
        public int EventId { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        
        public bool IsActive { get; set; }
    }
}
