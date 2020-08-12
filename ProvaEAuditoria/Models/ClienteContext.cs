using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaEAuditoria.Models;

namespace ProvaEAuditoria.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options)
            :base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<ProvaEAuditoria.Models.Filmes> Filmes { get; set; }
    }
}
