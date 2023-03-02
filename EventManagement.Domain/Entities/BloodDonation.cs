using System;

namespace EventManagement.Domain {
    public class BloodDonation : IBloodDonation {
        public int DonationId { get; set; }
        public int DonorId { get; set; }
        public bool Donated { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationLocation { get; set; }
    }
}
