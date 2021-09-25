using LocationRESTAPI.Models.DataTransferObjects;

namespace LocationRESTAPI.Models.Extensions
{
    /// <summary>
    /// UserLocation model extensions
    /// </summary>
    public static class UserLocationExtensions
    {
        /// <summary>
        /// Convert UserLocation model into DTO
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static UserLocationDTO ToDTO(this UserLocation location)
        {
            var dto = new UserLocationDTO
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                UserId = location.User.Id,
                DateTime = location.DateTime
            };

            return dto;
        }
    }
}
