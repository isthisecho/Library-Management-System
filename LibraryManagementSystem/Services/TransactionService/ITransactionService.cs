using LibraryManagementSystem.API.Entities;

namespace Library.API.Services
{
    public interface ITransactionService
    {

        Task<Transaction?> GetTransactionById(Guid id);

        Task<Transaction?> BorrowBook(Transaction transaction);
        Task RefundBook(Guid id);

    }
}
