using JobTracking.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.DataAccess.Persistance
{
    /// <summary>
    /// Represents the database context for the Job Tracking application.
    /// Manages entity sets and database connection configuration.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// DbSet representing Users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }
        
        /// <summary>
        /// DbSet representing JobAds in the database.
        /// </summary>
        public DbSet<JobAd> JobAds { get; set; }
        
        /// <summary>
        /// DbSet representing JobApplications in the database.
        /// </summary>
        public DbSet<JobApplication> JobApplications { get; set; }
        
        /// <summary>
        /// Configures the database connection if not already configured.
        /// Uses LocalDB SQL Server instance with a trusted connection.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=JobTracking;Trusted_Connection=true;");
            }
        }
    }
}