using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.Entities;
using DKbase.web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        [HttpGet]
        public List<Farmacia> Get()
        {
            return acceso.RecuperarFarmacias();
        }
    }
}
