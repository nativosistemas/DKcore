﻿using DKbase.dll;
using DKbase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKcore.Business
{
    public class CoreService : ICoreService
    {
        public cDllPedido TomarPedidoConIdCarrito(TomarPedidoConIdCarritoRequest pValue)
        {
            DKbase.dll.cDllPedido o = new DKbase.dll.cDllPedido();
            o.Error = "Hola MundoUUUUU";
            o.MensajeEnFactura = "Hola MundoUUUUU";
            return o;
        }
    }
}
