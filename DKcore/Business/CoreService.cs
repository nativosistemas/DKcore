using DKbase.dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKcore.Business
{
    public class CoreService : ICoreService
    {
        public cDllPedido TomarPedidoConIdCarrito(post_TomarPedidoConIdCarrito pValue)
        {
            DKbase.dll.cDllPedido o = new DKbase.dll.cDllPedido();
            o.Error = "Hola MundoUUUUU";
            o.MensajeEnFactura = "Hola MundoUUUUU";
            return o;
        }
    }
}
