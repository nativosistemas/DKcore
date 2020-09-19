﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKbase.dll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DKcore.Business;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TomarPedidoConIdCarritoController : ControllerBase
    {
        private readonly ICoreService coreService;

        public TomarPedidoConIdCarritoController(ICoreService coreService)
        {
            this.coreService = coreService;
        }
        [HttpGet]
        public DKbase.dll.cDllPedido Get()
        {
            return coreService.TomarPedidoConIdCarrito(new post_TomarPedidoConIdCarrito());
        }
        [HttpPost]
        public IActionResult Create([FromBody] post_TomarPedidoConIdCarrito parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(coreService.TomarPedidoConIdCarrito(parameter));
        }



}
}