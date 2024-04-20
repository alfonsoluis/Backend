using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Entity
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(b => b.Id);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "El Imperio FInal",
                    Author = "Brandon Sanderson",
                    Genre = "Fantasia",
                    PublishDate = new DateTime(2021, 1, 1),
                    
                },
                new Book
                {
                    Id = 2,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Genre = "Ciencia Ficcion",
                    PublishDate = new DateTime(2023, 1, 1),
                },
                new Book
                {
                    Id = 3,
                    Title = "Python Programming",
                    Author = "Juan Manuel Mosqueda",
                    Genre = "Programming",
                    PublishDate = new DateTime(2022, 1, 1),
                    
                }
            );
        }
    }
}
