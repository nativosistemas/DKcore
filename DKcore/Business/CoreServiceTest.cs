using DKbase.dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKcore.Business
{
    public class CoreServiceTest : ICoreService
    {
        public cDllPedido TomarPedidoConIdCarrito(post_TomarPedidoConIdCarrito pValue) 
        {
            DKbase.dll.cDllPedido o = new DKbase.dll.cDllPedido();
            o.Error = "Hola MundoAAAA";
            o.MensajeEnFactura = "Hola MundoAAAAJJJ";
            return o;
        }
    }
}
