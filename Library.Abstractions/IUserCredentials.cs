
namespace LibraryManagementSystem.Abstractions
{
    public interface IUserCredentials :IBaseEntity
    {
         string UserName { get; set; }
         string Password { get; set; }
    }
}
