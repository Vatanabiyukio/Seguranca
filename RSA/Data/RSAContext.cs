#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RSA.Modelos;
using RSA.Modelos.Chaves;

namespace RSA.Data
{
    public class RSAContext : DbContext
    {
        public RSAContext (DbContextOptions<RSAContext> options)
            : base(options)
        {
        }

        public DbSet<RSA.Modelos.Mensagem> Mensagem { get; set; }

        public DbSet<RSA.Modelos.Chaves.Privada> Privada { get; set; }

        public DbSet<RSA.Modelos.Chaves.Publica> Publica { get; set; }

        public DbSet<RSA.Modelos.Chaves.Comum> Comum { get; set; }
    }
}
