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

        /// <summary>
        /// Controller constructor with injected logger
        /// </summary>
        /// <param name="logger"></param>
        public UserLocationController(ILogger<UserLocationController> logger)
        {
            _logger = logger;
        }
    }
}
