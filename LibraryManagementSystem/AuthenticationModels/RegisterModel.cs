using LibraryManagementSystem.Abstractions;

namespace Library.API.AuthenticationModels
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

    }
}
