using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Abstractions
{
    public interface IUserCredentials
    {
        void SignUp (UserCredentials credentials);
        void Login  (UserCredentials credentials);
    }
}
