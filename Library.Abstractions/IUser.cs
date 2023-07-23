namespace LibraryManagementSystem.Abstractions
{

    public enum UserRole { Admin = 0, User }

    public interface IUser : IBaseEntity    
    {
        string                     Name                     { get; set; }
        string                     Email                    { get; set; }
        byte[]                     PasswordHash             { get; set; }
        byte[]                     PasswordSalt             { get; set; }
        UserRole                   UserRole                 { get; set; } 
        IEnumerable<ITransaction>? Transactions             { get; set; }


    }
}
