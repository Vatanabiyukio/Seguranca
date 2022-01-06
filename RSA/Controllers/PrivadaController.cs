#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSA.Data;
using RSA.Modelos.Chaves;

namespace RSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PrivadaController : ControllerBase
    {
        private readonly RSAContext _context;

        public PrivadaController(RSAContext context)
        {
            _context = context;
        }

        // GET: api/Privada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Privada>>> GetPrivada()
        {
            return await _context.Privada.ToListAsync();
        }

        // GET: api/Privada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Privada>> GetPrivada(Guid id)
        {
            var privada = await _context.Privada.FindAsync(id);

            if (privada == null)
            {
                return NotFound();
            }

            return privada;
        }

        // PUT: api/Privada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivada(Guid id, Privada privada)
        {
            if (id != privada.Id)
            {
                return BadRequest();
            }

            _context.Entry(privada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Privada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Privada>> PostPrivada(Privada privada)
        {
            _context.Privada.Add(privada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrivada", new { id = privada.Id }, privada);
        }

        // DELETE: api/Privada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivada(Guid id)
        {
            var privada = await _context.Privada.FindAsync(id);
            if (privada == null)
            {
                return NotFound();
            }

            _context.Privada.Remove(privada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrivadaExists(Guid id)
        {
            return _context.Privada.Any(e => e.Id == id);
        }
    }
}
