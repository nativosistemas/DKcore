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
        //[Authorize]
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
        [HttpPost]
        public DKbase.Entities.cSincronizadorApp Create([FromBody] DKbase.Entities.AppPedido parameter)
        {
            DKbase.Entities.cSincronizadorApp result = new DKbase.Entities.cSincronizadorApp();
            result.listaFarmacia = accesoApp.RecuperarFarmacias(parameter.promotor);
            result.listaLaboratorio = accesoApp.GetLaboratorios();
            result.listaModulo = accesoApp.RecuperarTodosModulos();
            result.listaAppInfoPedido = accesoApp.RecuperarTodoInfoPedidos(parameter.promotor);
            if (parameter.pedidoModulos != null && parameter.pedidoModulos.Count > 0)
            {
                result.pedidoGuid = accesoApp.AddPedido(parameter);
            }
            return result;
        }
    }
}
