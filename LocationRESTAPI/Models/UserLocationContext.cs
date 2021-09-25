using Microsoft.EntityFrameworkCore;

namespace LocationRESTAPI.Models
{
    /// <summary>
    /// User location data base context
    /// </summary>
    public class UserLocationContext : DbContext
    {
        /// <summary>
        /// Data base context constructor with injected options
        /// </summary>
        /// <param name="options"></param>
        public UserLocationContext(DbContextOptions<UserLocationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// User entities
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// User location entities
        /// </summary>
        public DbSet<UserLocation> UserLocations { get; set; }
    }
}
