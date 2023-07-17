using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.DataLayer.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class User : IUser, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public  Guid        Id             { get ; set ; } = Guid.Empty;
        public  string      Name           { get ; set ; }
        public  string      Email          { get ; set ; }
        public  string      UserName       { get ; set ; }
        public  string      Password       { get ; set ; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
