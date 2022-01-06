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
    public class ComumController : ControllerBase
    {
        private readonly RSAContext _context;

        public ComumController(RSAContext context)
        {
            _context = context;
        }

        // GET: api/Comum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comum>>> GetComum()
        {
            return await _context.Comum.ToListAsync();
        }

        // GET: api/Comum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comum>> GetComum(Guid id)
        {
            var comum = await _context.Comum.FindAsync(id);

            if (comum == null)
            {
                return NotFound();
            }

            return comum;
        }

        // PUT: api/Comum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComum(Guid id, Comum comum)
        {
            if (id != comum.Id)
            {
                return BadRequest();
            }

            _context.Entry(comum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComumExists(id))
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

        // POST: api/Comum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comum>> PostComum(Comum comum)
        {
            _context.Comum.Add(comum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComum", new { id = comum.Id }, comum);
        }

        // DELETE: api/Comum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComum(Guid id)
        {
            var comum = await _context.Comum.FindAsync(id);
            if (comum == null)
            {
                return NotFound();
            }

            _context.Comum.Remove(comum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComumExists(Guid id)
        {
            return _context.Comum.Any(e => e.Id == id);
        }
    }
}
