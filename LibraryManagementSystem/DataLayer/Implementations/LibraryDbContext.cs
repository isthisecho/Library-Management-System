using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.API.Entities;
using LibraryManagementSystem.DataLayer.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.DataLayer.Implementations
{
    public class LibraryDbContext : DbContext
    {
        
        public DbSet<Book>              Books                   { get; set; } 
        public DbSet<User>              Users                   { get; set; }
        public DbSet<Transaction>       Transactions            { get; set; }


        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
       {
       }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


    }
}
