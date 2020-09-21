using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DKcore.Entities
{
    public class User
    {
        public int id { get; set; }
        public int cli_codigo { get; set; }
        public string login { get; set; }

        [JsonIgnore]
        public string pass { get; set; }
    }
}
