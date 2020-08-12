using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class LocacaoContext : DbContext
    {
        public LocacaoContext(DbContextOptions<LocacaoContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Locacao>()
        //    //    .HasOne(p => p.Filme);
        //}

        public DbSet<Locacao> Locacao { get; set; }
    }
}
