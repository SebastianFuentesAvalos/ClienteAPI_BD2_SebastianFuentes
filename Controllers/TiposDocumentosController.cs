using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposDocumentosController : ControllerBase
    {
        // Datos de ejemplo hardcodeados (reemplaza con acceso a DB)
        private static readonly List<object> tiposDocumentos = new List<object>
        {
            new { Id = 1, Nombre = "DNI" },
            new { Id = 2, Nombre = "Pasaporte" },
            new { Id = 3, Nombre = "Carnet de extranjería" }
        };

        // GET: api/TiposDocumentos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tiposDocumentos);
        }

        // GET: api/TiposDocumentos/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tipo = tiposDocumentos.Find(t => (int)t.GetType().GetProperty("Id").GetValue(t) == id);
            if (tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }
    }
}