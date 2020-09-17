using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        // GET: api/<PruebaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var table  = DKbase.baseDatos.StoredProcedure.RecuperarTodasSucursales();
            List<string> l = new List<string>();
            foreach (DataRow item in table.Rows)
            {
                l.Add(item[1].ToString());
            }
            return l.ToArray();// new string[] { "value1", "value2" };
        }

        // GET api/<PruebaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PruebaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PruebaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PruebaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
