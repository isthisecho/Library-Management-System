using Library.API.Entities;
using LibraryManagementSystem.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.API.Entities
{
    public class Transaction : BaseEntity
    {
        [Required]
        public   Guid                        UserId              { get ; set ; }

        [Required]
        public   Guid                        BookId              { get ; set ; }

        public   DateTime?                   BorrowDate          { get ; set ; }
        public   DateTime?                   ReturnDate          { get ; set ; }


        [JsonIgnore]
        public   User                       User                { get; set  ; } = new User();

        [JsonIgnore]
        public   Book                       Book                { get; set  ; } = new Book();

    //   IUser     ITransaction.User   { get => User; set => User = (User)value; }
    //
    //   IBook     ITransaction.Book   { get => Book; set => Book = (Book)value; }
    }
}
