using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.app;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
       // [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] DKbase.Entities.AppPedido parameter)
        {
            return Ok(accesoApp.AddPedido(parameter));
       
        }
    }
}
