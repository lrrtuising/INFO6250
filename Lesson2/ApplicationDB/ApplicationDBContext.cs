using Lesson2.Migrations;
using Microsoft.EntityFrameworkCore;
using Lesson2.Models;

namespace Lesson2.ApplicationDB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Username).IsUnique();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Book)
                    .WithMany(b => b.Orders)
                    .HasForeignKey(o => o.BookId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
            });
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData( 
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "A novel set in the Jazz Age that tells the story of Jay Gatsby's unrequited love for Daisy Buchanan.", Price = 10.99m }, 
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Description = "A novel about racial injustice in the Deep South, seen through the eyes of young Scout Finch.", Price = 8.99m }, 
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Description = "A dystopian novel that explores themes of totalitarianism, surveillance, and individuality.", Price = 9.99m }, 
                new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Description = "A classic romance novel that delves into issues of class, marriage, and societal expectations in 19th-century England.", Price = 7.99m }, 
                new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Description = "A coming-of-age novel that follows the experiences of Holden Caulfield as he navigates adolescence and alienation.", Price = 6.99m } 
                );
            
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Alice", Password = "123456" },
                new User { Id = 2, Username = "Bob", Password = "123456" },
                new User { Id = 3, Username = "Charlie", Password="123456" }
            );
            
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, UserId = 1, BookId = 1, Quantity = 1, TotalPrice = 10.99m },
                new Order { Id = 2, UserId = 1, BookId = 3, Quantity = 2, TotalPrice = 19.98m },
                new Order { Id = 3, UserId = 2, BookId = 2, Quantity = 1, TotalPrice = 8.99m }
            );
        }
    }
}

