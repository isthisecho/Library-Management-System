using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Abstractions
{
    public interface ITransaction
    {
        void BorrowBook(Transaction transaction);
        void RefundBook(Transaction transaction);
    }
}
