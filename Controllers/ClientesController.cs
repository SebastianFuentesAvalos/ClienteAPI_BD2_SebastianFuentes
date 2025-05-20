using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Data;
using ClienteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public ClientesController(BdClientesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            return cliente;
        }
    }
}
 