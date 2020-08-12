using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //            => options.UseSqlServer("DataSource=app.db");

        public FilmeContext() { }

        public DbSet<Filmes> Filmes { get; set; }
    }
}
