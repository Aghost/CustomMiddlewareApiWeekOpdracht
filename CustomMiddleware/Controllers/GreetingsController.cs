using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        [HttpGet]
        public IActionResult DoGreet() {
            return Ok("Hello");
        }

        [HttpGet]
        [Route("saybye")]
        public IActionResult SayBye() {
            return Ok("Bye");
        }
    }
}
