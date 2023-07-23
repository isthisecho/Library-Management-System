namespace LibraryManagementSystem.Abstractions
{
    public interface ITransaction : IBaseEntity
    {
        Guid     UserId     { get; set; }
        Guid     BookId     { get; set; }
        DateTime BorrowDate { get; set; }
        DateTime ReturnDate { get; set; }

        IUser    User       { get; set; }
        IBook    Book       { get; set; }
    }
}
