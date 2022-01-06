#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSA.Data;
using RSA.Modelos;

namespace RSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MensagemController : ControllerBase
    {
        private readonly RSAContext _context;

        public MensagemController(RSAContext context)
        {
            _context = context;
        }

        // GET: api/Mensagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagem()
        {
            var msg = await _context.Mensagem.ToListAsync();
            foreach (var m in msg)
            {
                var comum = await _context.Comum.FindAsync(m.ComumId);
                m.ChaveComum = comum!;
                var pub = await _context.Publica.FindAsync(m.PublicaId);
                m.ChavePublica = pub!;
                var priv = await _context.Privada.FindAsync(m.PrivadaId);
                m.ChavePrivada = priv!;
            }

            return msg;
        }

        // GET: api/Mensagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(Guid id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);

            if (mensagem == null)
            {
                return NotFound();
            }
            
            var comum = await _context.Comum.FindAsync(mensagem.ComumId);
            mensagem.ChaveComum = comum!;
            var pub = await _context.Publica.FindAsync(mensagem.PublicaId);
            mensagem.ChavePublica = pub!;
            var priv = await _context.Privada.FindAsync(mensagem.PrivadaId);
            mensagem.ChavePrivada = priv!;

            return mensagem;
        }

        // PUT: api/Mensagem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensagem(Guid id, Mensagem mensagem)
        {
            if (id != mensagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(mensagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(id))
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
        
        // POST: api/Mensagem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mensagem>> PostMensagem(Mensagem mensagem)
        {
            mensagem.ParChavesValida =
                Util.Essencial.InversoModular(mensagem.ChavePrivada.D, mensagem.ChavePrivada.N).Equals(mensagem.ChavePublica.E) &&
                mensagem.ChavePrivada.N.Equals(mensagem.ChavePublica.N);
            _context.Mensagem.Add(mensagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMensagem", new { id = mensagem.Id }, mensagem);
        }

        // DELETE: api/Mensagem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagem(Guid id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MensagemExists(Guid id)
        {
            return _context.Mensagem.Any(e => e.Id == id);
        }
    }
}
