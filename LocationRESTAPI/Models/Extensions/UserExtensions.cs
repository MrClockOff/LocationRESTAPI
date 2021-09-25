using LocationRESTAPI.Models.DataTransferObjects;

namespace LocationRESTAPI.Models.Extensions
{
    /// <summary>
    /// User model extensions
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// Convert user model into DTO
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserDTO ToDTO(this User user)
        {
            var dto = new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };

            return dto;
        }
    }
}
