using Library.API.AuthenticationModels;
using LibraryManagementSystem.API.Entities;

namespace Library.API.Services.UserService
{
    public interface IUserService
    {
        
        Task<User?> SignUp(RegisterModel    user);
        Task<string> Login(LoginModel user);


    }
}
