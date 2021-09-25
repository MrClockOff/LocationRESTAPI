using System;
namespace LocationRESTAPI.Models.DataTransferObjects
{
    /// <summary>
    /// User location data trasfer object
    /// </summary>
    public class UserLocationDTO
    {
        /// <summary>
        /// Related user's Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Latitude in degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in degrees
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Location date and time
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
