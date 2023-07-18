using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.DataLayer.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Entities
{
    public class Transaction :  IEntity
    {
        public   Guid                       Id                 { get ; set ; }

        public   Guid                       UserId             { get ; set ; }

        public   Guid                       BookId             { get ; set ; }
        public   DateTime                   BorrowDate         { get ; set ; }
        public   DateTime                   ReturnDate         { get ; set ; }

        public   User        User               { get; set  ; }
        public   Book        Book               { get; set  ; }
    }
}
