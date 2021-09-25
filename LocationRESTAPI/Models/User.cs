using System;
using System.Collections.Generic;

namespace LocationRESTAPI.Models
{
    /// <summary>
    /// User model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Model constructor
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// User's unique Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User's full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User's unique email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's related locations
        /// </summary>
        public List<UserLocation> Locations { get; set; }
    }
}
