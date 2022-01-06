using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSA.Modelos.Chaves
{

    public class Publica
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();
        public int E { get; set; }
        public int N { get; set; }

        public ICollection<Mensagem> Mensagems { get; set; }

        public override string ToString()
        {
            return $@"ID:{Id}, E: {E}, N: {N}";
        }
    }
}