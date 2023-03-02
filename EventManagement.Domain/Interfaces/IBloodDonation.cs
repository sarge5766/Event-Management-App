using System;

namespace EventManagement.Domain {
    public interface IBloodDonation {
        int DonationId { get; set; }
        int DonorId { get; set; }
        bool Donated { get; set; }
        DateTime DonationDate { get; set; }
        string DonationLocation { get; set; }
    }
}
