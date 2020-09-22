using DKbase.dll;
using DKbase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKcore.Business
{
    public interface ICoreService
    {
        cDllPedido TomarPedidoConIdCarrito(TomarPedidoConIdCarritoRequest pValue);
    }
}
