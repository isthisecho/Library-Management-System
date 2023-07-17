using LibraryManagementSystem.Abstractions;
using LibraryManagementSystem.DataLayer.Abstractions;
using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataLayer.Implementations
{
    public class LibraryDbContext : DbContext
    {

        public DbSet<Book>        Books         { get; set; }
        public DbSet<User>        Users         { get; set; }
        public DbSet<Transaction> Transactions  { get; set; }


        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(book =>
            {
                book.ToTable(nameof(Book));

                //KEY
                book.HasKey  ( x => x.Id          ) .HasName("pk_book_id");

                //COLUMNS
                book.Property( x => x.Id          ) .HasColumnName("ID").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired();
                book.Property( x => x.Name        ) .HasColumnName("Name").HasColumnType("character varying").HasMaxLength(100);
                book.Property( x => x.Description ) .HasColumnName("Description").HasColumnType("character varying").HasMaxLength(100);
                book.Property( x => x.Author      ) .HasColumnName("Author").HasColumnType("character varying").HasMaxLength(100);

                //RELATIONS
                book.HasMany(b => b.Transactions).WithOne(t => t.Book).HasForeignKey(t => t.BookId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>(user => 
            {

                user.ToTable(nameof(User));

                //KEY
                user.HasKey   (x => x.Id      ) .HasName("pk_user_id");

                //COLUMNS
                user.Property (x => x.Id      ) .HasColumnName("ID"      ) .HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired();
                user.Property (x => x.Name    ) .HasColumnName("Name"    ) .HasColumnType("character varying").HasMaxLength(100);
                user.Property (x => x.Email   ) .HasColumnName("Email"   ) .HasColumnType("character varying").HasMaxLength(100);
                user.Property (x => x.UserName) .HasColumnName("Username") .HasColumnType("character varying").HasMaxLength(100);
                user.Property (x => x.Password) .HasColumnName("Password") .HasColumnType("character varying").HasMaxLength(100);

                //RELATIONS
                user.HasMany(u => u.Transactions).WithOne(t => t.User).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Transaction>(transaction => 
            {
                transaction.ToTable(nameof(Transaction));

                //KEY
                transaction.HasKey  (x => x.Id).HasName("pk_transaction_id");

                //COLUMNS
                transaction.Property(x => x.Id).HasColumnName("ID").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").IsRequired();
                transaction.Property(x => x.BorrowDate).HasColumnName("BorrowDate").HasColumnType("DATE").IsRequired();
                transaction.Property(x => x.ReturnDate).HasColumnName("ReturnDate").HasColumnType("DATE").IsRequired();

                //RELATIONS
                transaction.HasOne(t => t.User).WithMany(u => u.Transactions).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
                transaction.HasOne(t => t.Book).WithMany(b => b.Transactions).HasForeignKey(t => t.BookId).OnDelete(DeleteBehavior.Restrict);



            });

                
        }
    }
}
