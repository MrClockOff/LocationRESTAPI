using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationRESTAPI.Models;
using LocationRESTAPI.Models.DataTransferObjects;
using LocationRESTAPI.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = await GetUser(userId);

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

        /// <summary>
        /// Get user's current location
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("users/{userId}/current")]
        public async Task<ActionResult<UserLocationDTO>> GetUserCurrentLocation(Guid userId)
        {
            // Check if user exists
            var user = await GetUser(userId);

            if (user == null)
            {
                return NotFound($"User not found (Id: {userId})");
            }

            // Get user's most recent location
            var recentLocation = user.Locations
                .OrderByDescending(location => location.DateTime)
                .FirstOrDefault();

            if (recentLocation == null)
            {
                return NotFound($"User current location not found (Id: {userId}");
            }

            var result = recentLocation.ToDTO();
            return result;
        }

        /// <summary>
        /// Get users's location history
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("users/{userId}/history")]
        public async Task<ActionResult<IEnumerable<UserLocationDTO>>> GetUserLocationHistory(Guid userId)
        {
            // Check if user exists
            var user = await GetUser(userId);

            if (user == null)
            {
                return NotFound($"User not found (Id: {userId})");
            }

            var result = user.Locations
                .Select(location => location.ToDTO())
                .ToList();

            return result;
        }

        /// <summary>
        /// Get user with specific Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private Task<User> GetUser(Guid userId)
        {
            return _userLocationContext.Users
                .Include(user => user.Locations)
                .FirstOrDefaultAsync(user => user.Id.Equals(userId));
        }
    }
}
