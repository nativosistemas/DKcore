using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.Models;
using DKcore.Helpers;
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

        [HttpGet]
        public string Get()
        {
            return "OK";
        }

    }
}
