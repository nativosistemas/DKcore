using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DKbase.Entities;
using DKbase.app;
using DKcore.Helpers;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public List<Modulo> Get()
        {
            return accesoApp.RecuperarTodosModulos();
        }
    }
}
