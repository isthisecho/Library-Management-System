using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.DataLayer.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace LibraryManagementSystem.Entities
{
    public class User :  IEntity
    {

        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Transaction> Transactions { get ; set ; }
    }
}
