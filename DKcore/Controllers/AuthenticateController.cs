using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.Models;
using DKcore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IUserService _userService;

        public AuthenticateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Nombre de usuario o contraseña incorrecta" });

            return Ok(response);
        }
    }
}
