using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DKcore.Helpers;
using DKbase.app;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SincronizadorAppController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public DKbase.Entities.cSincronizadorApp Get(string ApNombre)
        {
            DKbase.Entities.cSincronizadorApp result = new DKbase.Entities.cSincronizadorApp();
            result.listaFarmacia = accesoApp.RecuperarFarmacias(ApNombre);
            result.listaLaboratorio = accesoApp.GetLaboratorios();
            result.listaModulo = accesoApp.RecuperarTodosModulos();
            result.listaAppInfoPedido = accesoApp.RecuperarTodoInfoPedidos(ApNombre);
            return result;
        }
    }
}
