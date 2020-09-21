using DKcore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKcore.Models
{
    public class AuthenticateResponse
    {
        public int id { get; set; }
        public int cli_codigo { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            id = user.id;
            cli_codigo = user.cli_codigo;            
            Token = token;
        }
    }
}
