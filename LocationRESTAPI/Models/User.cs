using System;

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
    }
}
