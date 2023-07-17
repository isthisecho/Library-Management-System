namespace LibraryManagementSystem.Abstractions
{
    public interface IBook
    {
        string  Name           { get; set; }
        string  Description    { get; set; }
        string  Author         { get; set; }

    }
}
