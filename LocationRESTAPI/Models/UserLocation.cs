using System;

namespace LocationRESTAPI.Models
{
    /// <summary>
    /// User location model which represent user's logged location and time
    /// </summary>
    public class UserLocation
    {
        /// <summary>
        /// Model constructor
        /// </summary>
        public UserLocation()
        {
        }

        /// <summary>
        /// Location entry unique Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Location latitude in degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Location longitude in degrees
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Entry date and time
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
