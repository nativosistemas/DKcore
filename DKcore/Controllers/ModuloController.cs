using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DKbase.Entities;
using DKbase.web;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        [HttpGet]
        public List<Modulo> Get()
        {
            return acceso.RecuperarTodosModulos();
        }
    }
}
