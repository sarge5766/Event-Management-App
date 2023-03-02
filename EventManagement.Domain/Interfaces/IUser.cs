namespace EventManagement.Domain {
    public interface IUser {
        int UserId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        int RoleId { get; set; }
    }
}
