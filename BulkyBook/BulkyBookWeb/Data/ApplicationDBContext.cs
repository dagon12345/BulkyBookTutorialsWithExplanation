using BulkyBookWeb.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<LibraryAssessment> lib_assessment { get; set; }
        public DbSet<MasterList> tbl_masterlist { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timestamp>().HasNoKey();
            // Other configurations
        }

    }
}
