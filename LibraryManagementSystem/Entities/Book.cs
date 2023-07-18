using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.DataLayer.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Book :   IEntity
    {
        public  Guid          Id            { get ; set ; }
        public  string       Name           { get ; set ; }
        public  string       Description    { get ; set ; }
        public  string       Author         { get ; set ; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
