using DKbase.dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKcore.Business
{
    public interface ICoreService
    {
        cDllPedido TomarPedidoConIdCarrito(post_TomarPedidoConIdCarrito pValue);
    }
}
