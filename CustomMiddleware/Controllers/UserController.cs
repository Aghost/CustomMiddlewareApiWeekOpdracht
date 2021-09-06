using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMiddleware.Interfaces;

namespace CustomMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try {
                return Ok(userService.Login(username, password));
            } catch(UnauthorizedAccessException uae) {
                return Problem($"false {uae}", statusCode: 401);
            } catch(Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
