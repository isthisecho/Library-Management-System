namespace LibraryManagementSystem.Abstractions
{
    public interface IBook
    {
        int     Id             { get; set; }
        string  Name           { get; set; }
        string  Description    { get; set; }
        string  Author         { get; set; }

    }
}
