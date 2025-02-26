using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TheQuyen.OnlinePainting.Data.Models;

namespace TheQuyen.OnlinePainting.Data.Context
{
    public class OnlinePaintingContext : DbContext
    {
        public OnlinePaintingContext(DbContextOptions<OnlinePaintingContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Painting>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            //DataSeeding
            modelBuilder.Entity<Artist>().HasData(
    new Artist
    {
        ArtistId = 1,
        Name = "Ma The Quyen",
        Bio = "No",
        BirthDate = new DateTime(2003, 06, 21),
        Nationality = "Viet Nam",
        Website = "PaintingOnline.Com"
    },
    new Artist
    {
        ArtistId = 2,
        Name = "Nguyen Van Do",
        Bio = "A sample artist bio",
        BirthDate = new DateTime(2003, 05, 02),
        Nationality = "VN",
        Website = "DoNguyen.com"
    }
);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Server=THEQUYEN\\THEQUYEN;Database=OnlinePaintingDB;Trusted_Connection=True; TrustServerCertificate=True")
               .UseLazyLoadingProxies();
        }
    }
}
