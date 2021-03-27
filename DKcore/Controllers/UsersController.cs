using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKbase.Models;
using DKcore.Helpers;
using DKcore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public string Get()
        {

            //System.Drawing.Image image = System.Drawing.Image.FromFile("C:\\ArchivosSitioWEB\\archivos\\laboratorio\\lab2.png");//
            //if (image != null)
            //{
            //    using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            //    {
            //        image.Save(m, image.RawFormat);
            //        byte[] imageBytes = m.ToArray();
            //        string base64String = Convert.ToBase64String(imageBytes);
                    
            //    }
            //}
            return "OK";
        }

    }
}
