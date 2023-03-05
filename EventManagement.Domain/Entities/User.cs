using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain {
    public class User : IUser {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
