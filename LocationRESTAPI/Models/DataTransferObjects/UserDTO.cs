using System;

namespace LocationRESTAPI.Models.DataTransferObjects
{
    /// <summary>
    /// User data transfer object
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// User's Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User's full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        public string Email { get; set; }
    }
}
