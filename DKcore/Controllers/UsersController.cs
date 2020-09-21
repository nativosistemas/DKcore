using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKcore.Helpers;
using DKcore.Models;
using DKcore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Nombre de usuario o contraseña incorrecta" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
