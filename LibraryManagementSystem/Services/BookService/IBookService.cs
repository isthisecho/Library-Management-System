using LibraryManagementSystem.API.Entities;

namespace Library.API.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetBooks                       ();
        Task<Book?>              GetBook       (Guid id          );
        Task<Book?>              AddBook       (Book book        );
        Task<Book?>              UpdateBook    (Guid id, Book book);
        void                     RemoveBook    (Guid id          );


    }
}
