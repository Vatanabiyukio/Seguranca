using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSA.Modelos.Chaves
{

    public class Privada
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();
        public int D { get; set; }
        public int N { get; set; }

        public List<Mensagem>? Mensagems { get; set; }

        public override string ToString()
        {
            return $@"ID:{Id}, D: {D}, N: {N}";
        }
    }
}