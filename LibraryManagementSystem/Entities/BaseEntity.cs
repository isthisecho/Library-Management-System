using LibraryManagementSystem.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
