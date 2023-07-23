using System.Transactions;

namespace LibraryManagementSystem.Abstractions
{
    public interface IBook : IBaseEntity
    {
        string  Name           { get; set; }
        string  Description    { get; set; }
        string  Author         { get; set; }

        IEnumerable<ITransaction>? Transactions { get; set; }


    }
}
