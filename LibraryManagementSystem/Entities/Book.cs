using LibraryManagementSystem.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.API.Entities;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.API.Entities
{
    public class Book : BaseEntity 
    {

        public  string                  Name          { get ; set ; } = string.Empty; 

        public  string                  Description   { get ; set ; } = string.Empty;
        public  string                  Author        { get ; set ; } = string.Empty;


        [JsonIgnore]
        public IEnumerable<Transaction>? Transactions { get ; set ; }

        //IEnumerable<ITransaction>? IBook.Transactions { get => Transactions; set => Transactions = value as IEnumerable<Transaction>; }
    }
}
