using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.app;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SincronizadorAppTestController : ControllerBase
    {
        [HttpPost]
        public DKbase.Entities.cSincronizadorApp Create([FromBody] DKbase.Entities.AppPedido parameter)
        {
            string strConnectionStringSQL = DKbase.Helper.getConnectionStringSQL_Desarrollo;
            DKbase.Entities.cSincronizadorApp result = new DKbase.Entities.cSincronizadorApp
            {
                listaFarmacia = accesoApp.RecuperarFarmacias(parameter.promotor, strConnectionStringSQL),
                listaLaboratorio = accesoApp.GetLaboratorios(strConnectionStringSQL),
                listaModulo = accesoApp.RecuperarTodosModulos(strConnectionStringSQL),
                listaAppInfoPedido = accesoApp.RecuperarTodoInfoPedidos(parameter.promotor, strConnectionStringSQL)
            };
            if (parameter.pedidoModulos != null && parameter.pedidoModulos.Count > 0)
            {
                result.pedidoGuid = accesoApp.AddPedido(parameter, strConnectionStringSQL);
            }
            result.listaAppPedidoModuloHistorial = accesoApp.RecuperarTodoPedidoModuloHistorial(parameter.promotor, strConnectionStringSQL);
            return result;
        }
    }
}
