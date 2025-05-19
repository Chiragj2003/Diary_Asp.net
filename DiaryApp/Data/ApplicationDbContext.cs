using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
                {
                    Id = 1,
                    Title = "First Entry",
                    Content = "This is the first entry in the diary.",
                    Created = new DateTime(2024, 05, 01, 10, 0, 0)
                },
                new DiaryEntry
                {
                    Id = 2,
                    Title = "Second Entry",
                    Content = "This is the second entry in the diary.",
                    Created = new DateTime(2024, 05, 02, 10, 0, 0)
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Third Entry",
                    Content = "This is the third entry in the diary.",
                    Created = new DateTime(2024, 05, 03, 10, 0, 0)
                }
            );
        }
    }
}

// This file is part of the DiaryApp project.
// 1. Create a model class
// 2. add DB set
// 3. add migration AddDiaryEntryTable
// 4. update database