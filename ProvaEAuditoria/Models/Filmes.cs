using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class Filmes
    {
        public Filmes()
        {
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public bool Lancamento { get; set; }

    }
}
