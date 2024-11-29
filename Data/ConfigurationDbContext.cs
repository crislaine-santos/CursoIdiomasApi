using CursoIdiomasApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomasApi.Data
{
    public class ConfigurationDbContext
    {
        public class ConfigDbContext : DbContext
        {
            public ConfigDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

           // public DbSet<Aluno> Alunos { get; set; }
           // public DbSet<Turma> Turmas { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Aluno>()
                     .HasOne(t => t.Turma)
                     .WithMany(a => a.Alunos)
                     .HasForeignKey(a => a.TurmaId)
                     .OnDelete(DeleteBehavior.Restrict); // Para evitar deleções em cascata
            }

        }
    }
}
