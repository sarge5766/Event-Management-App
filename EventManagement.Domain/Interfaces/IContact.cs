namespace EventManagement.Domain {
    public interface IContact {
        int ContactId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string MobileNumber { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zipcode { get; set; }
        BloodType BloodType { get; set; }
        int ReferredBy { get; set; }
    }
}
