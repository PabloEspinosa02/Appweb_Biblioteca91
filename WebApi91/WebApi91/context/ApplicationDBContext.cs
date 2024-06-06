using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebApi91.context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions options) : base(options) { }
         
        // modelos

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Incertar en la tabla Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Pkusuario = 1,
                    Nombre = "Pablo",
                    User = "Usuario1",
                    Password = "123",
                    Fkrol = 1
                }
                );
            modelBuilder.Entity<Rol>().HasData(
            new Rol
            {
                PKrol = 1,
                Nombre = "sa"

            });
            


        }
    }

    }

