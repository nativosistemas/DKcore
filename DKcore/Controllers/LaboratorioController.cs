using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.app;
using DKbase.Entities;
using DKcore.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratorioController : ControllerBase
    {
        //[Authorize]
        [HttpGet]
        public List<Laboratorio> Get()
        {
            return accesoApp.GetLaboratorios();
        }
    }
}
