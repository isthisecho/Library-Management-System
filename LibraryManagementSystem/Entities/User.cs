using LibraryManagementSystem.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.API.Entities;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.API.Entities { 
    public class User : BaseEntity
    {
        public  string      Name                      { get ; set ; } = string.Empty;
            
        public  string      Email                     { get ; set ; } = string.Empty;

        public byte[]       PasswordHash              { get; set; } = Array.Empty<byte>();

        public byte[] PasswordSalt { get; set; }        = Array.Empty<byte>();

        public  UserRole    UserRole                  { get; set; }


        [JsonIgnore]
        public IEnumerable<Transaction>? Transactions { get; set; }

      //  IEnumerable<ITransaction>? IUser.Transactions { get => Transactions; set => Transactions = value as IEnumerable<Transaction>; }
    }
}
