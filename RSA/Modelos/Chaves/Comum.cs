using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSA.Modelos.Chaves
{

    public class Comum
    {
        [Key]
        public Guid Id { get; init; } = new Guid();
        private ICollection<Mensagem> Mensagems { get; set; }
        
        public override string ToString()
        {
            return $@"ID:{Id}";
        }
    }
}