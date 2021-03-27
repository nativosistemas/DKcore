using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.app;
using DKcore.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        [Authorize]
        [HttpGet]
        public List<DKbase.Entities.AppInfoPedido> Get(string ApNombre)
        {
            return accesoApp.RecuperarTodoInfoPedidos(ApNombre);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] DKbase.Entities.AppPedido parameter)
        {
            return Ok(accesoApp.AddPedido(parameter));
       
        }
    }
}
