using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DKbase.generales;
using Microsoft.AspNetCore.Mvc;

namespace DKcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string r, string n, string an, string al, string c, string re)
        {
            string ruta = r;
            string nombre = n;
            string strAncho = an;
            string strAlto = al;
            string strColor = string.Empty;
            if (!string.IsNullOrEmpty(c))
            {
                if (c.Trim() != string.Empty)
                {
                    strColor = "#" + c;
                }
            }
            bool boolAlto = false;
            if (!string.IsNullOrEmpty(re))
            {
                boolAlto = true;
            }
            System.Drawing.Image oImg = DKbase.generales.cThumbnail.obtenerImagen(ruta, nombre, strAncho, strAlto, strColor, boolAlto);
            if (oImg != null)
            {
                Byte[] b = ImageToByteArray(oImg);
                if (b != null)
                {
                    return File(b, "image/jpeg");// ImageFormat.Jpeg
                }
            }
            return Content("No se encontró el elemento de imagen");
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                string nombreFuncion = "ImageToByteArray";
                Log.LogError(MethodBase.GetCurrentMethod(), ex, DateTime.Now, nombreFuncion);
                return null;
            }

        }
    }
}
