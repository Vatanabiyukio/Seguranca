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
    public class PublicaController : ControllerBase
    {
        private readonly RSAContext _context;

        public PublicaController(RSAContext context)
        {
            _context = context;
        }

        // GET: api/Publica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publica>>> GetPublica()
        {
            return await _context.Publica.ToListAsync();
        }

        // GET: api/Publica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publica>> GetPublica(Guid id)
        {
            var publica = await _context.Publica.FindAsync(id);

            if (publica == null)
            {
                return NotFound();
            }

            return publica;
        }

        // PUT: api/Publica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublica(Guid id, Publica publica)
        {
            if (id != publica.Id)
            {
                return BadRequest();
            }

            _context.Entry(publica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicaExists(id))
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

        // POST: api/Publica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publica>> PostPublica(Publica publica)
        {
            _context.Publica.Add(publica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublica", new { id = publica.Id }, publica);
        }

        // DELETE: api/Publica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublica(Guid id)
        {
            var publica = await _context.Publica.FindAsync(id);
            if (publica == null)
            {
                return NotFound();
            }

            _context.Publica.Remove(publica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicaExists(Guid id)
        {
            return _context.Publica.Any(e => e.Id == id);
        }
    }
}
