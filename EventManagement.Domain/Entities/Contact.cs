using System.Collections.Generic;

namespace EventManagement.Domain {
    public class Contact {
        public string Address { get; set; }
        public BloodType BloodType { get; set; }
        public string City { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public int ReferredBy { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public List<Event> ContactEvents { get; set; }
    }
}