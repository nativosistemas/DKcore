using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.Entities;
using DKbase.app;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DKcore.Helpers;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public List<Farmacia> Get(string ApNombre)
        {
            return accesoApp.RecuperarFarmacias(ApNombre);
        }
    }
}
