using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Abstractions
{
    public interface IBook
    {

        Book  GetBook   ( Guid id   );
        void DeleteBook ( Guid id   );
        void AddBook    ( Book book );
        void UpdateBook ( Book book );
        IEnumerable<Book> GetBooks ();



    }
}
