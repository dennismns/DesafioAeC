using DesafioAec.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAec.Infra.DataContext
{
    public class AppDataContext: DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>()
                .Property(x => x.Titulo)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Curso>()
                .Property(x => x.NomeProfessor)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Curso>()
               .Property(x => x.CargaHoraria)
               .IsRequired();

            modelBuilder.Entity<Curso>()
              .Property(x => x.Descricao)             
              .IsRequired();
        }

       

        public DbSet<Curso> Cursos { get; set; }
       
    }
}
