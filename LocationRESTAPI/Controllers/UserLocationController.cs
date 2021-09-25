using System;
using System.Threading.Tasks;
using LocationRESTAPI.Models;
using LocationRESTAPI.Models.DataTransferObjects;
using LocationRESTAPI.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocationRESTAPI.Controllers
{
    /// <summary>
    /// User location controller for handling user location logging and retrieval
    /// </summary>
    [ApiController]
    [Route("api/location")]
    public class UserLocationController : ControllerBase
    {
        private readonly ILogger<UserLocationController> _logger;
        private readonly UserLocationContext _userLocationContext;

        /// <summary>
        /// Controller constructor with injected ILogger and UserLocationContext
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userLocationContext"></param>
        public UserLocationController(
            ILogger<UserLocationController> logger,
            UserLocationContext userLocationContext)
        {
            _logger = logger;
            _userLocationContext = userLocationContext;
        }

        /// <summary>
        /// Post user location
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost("users/{userId}")]
        public async Task<ActionResult<UserLocationDTO>> PostUserLocation(Guid userId, [FromBody] LocationDTO location)
        {
            // Check first that user does exist
            var user = await _userLocationContext.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound($"User not found (Id: {userId})");
            }

            // Add user location
            var userLocation = new UserLocation
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                DateTime = DateTime.UtcNow
            };

            _userLocationContext.UserLocations.Add(userLocation);
            user.Locations.Add(userLocation);
            await _userLocationContext.SaveChangesAsync();

            var result = userLocation.ToDTO();
            return result;
        }            
    }
}
