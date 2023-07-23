using LibraryManagementSystem.DataLayer.Implementations;
using LibraryManagementSystem.API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using LibraryManagementSystem.DataLayer.Abstractions;

namespace Library.API.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;


        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>?> GetBooks()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book?> GetBook(Guid id)
        {
            return await _bookRepository.Get(id)!;
        }

        public async Task<Book?> AddBook(Book book)
        {
            return await _bookRepository.Create(book)!;
        }

        public async Task<Book?> UpdateBook(Guid id, Book book)
        {
            return await _bookRepository.Update(id, book)!;
        }

        public async void  RemoveBook(Guid id)
        {
            await _bookRepository.Delete(id)!;
        }
        
    }
}
