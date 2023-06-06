using backend.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Data
{
    public class BackendDataContext : DbContext
    {
        public BackendDataContext(DbContextOptions<BackendDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<PessoaFisica>()
                .HasIndex(p => new { p.Cpf })
                .IsUnique(true);
        }   
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
    }
}
