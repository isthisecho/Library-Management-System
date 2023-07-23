using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.API.Entities;
using LibraryManagementSystem.DataLayer.Abstractions;

namespace Library.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Book> _bookRepository;



        public TransactionService(IRepository<Transaction> transactionRepository, IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Transaction?> GetTransactionById(Guid id)
        {
            return await _transactionRepository.Get(id);

        }

        public async Task<Transaction?> BorrowBook(Transaction transaction)
        {
            var selectedUser = await _userRepository.Get(transaction.UserId);
            var selectedBook = await _bookRepository.Get(transaction.BookId);

            transaction.User = selectedUser!;
            transaction.Book = selectedBook!;


          // var activeTransaction = selectedBook?.Transactions?.FirstOrDefault(t => t.ReturnDate == null);


            return await _transactionRepository.Create(transaction);
        }



        public async Task RefundBook(Guid id)
        {
             await _transactionRepository.Delete(id);
        }
    }
}
