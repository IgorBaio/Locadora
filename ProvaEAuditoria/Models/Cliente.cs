using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
