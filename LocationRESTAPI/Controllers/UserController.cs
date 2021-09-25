using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationRESTAPI.Models;
using LocationRESTAPI.Models.DataTransferObjects;
using LocationRESTAPI.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocationRESTAPI.Controllers
{
    /// <summary>
    /// User controller for handling user requests
    /// </summary>
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserLocationContext _userLocationContext;

        /// <summary>
        /// Controller constructor with injected UserLocationContext
        /// </summary>
        /// <param name="userLocationContext"></param>
        public UserController(UserLocationContext userLocationContext)
        {
            _userLocationContext = userLocationContext;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userLocationContext.Users
                .Select(user => user.ToDTO())
                .ToListAsync();
            return users;
        }
    }
}
