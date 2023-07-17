namespace LibraryManagementSystem.Abstractions
{
    public interface ITransaction
    {
        Guid UserId         { get; set; }
        Guid BookId         { get; set; }
        DateTime BorrowDate { get; set; }
        DateTime ReturnDate { get; set; }
    }
}
