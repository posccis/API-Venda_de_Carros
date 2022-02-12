using System;
using Microsoft.EntityFrameworkCore;
using Sistema_Vendas.API.Models;

namespace Sistema_Vendas.API.Data
{
    public class VendasContext : DbContext
    {
        public VendasContext(DbContextOptions<VendasContext> options) : base(options){}
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Motocicleta> Motocicletas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Usuario>().HasKey( user => user.Id);
            builder.Entity<Categoria>().HasKey( categ => categ.Id);
            builder.Entity<Endereco>().HasKey( ender => ender.UsuarioId);
            builder.Entity<Carro>().HasKey( car => car.UsuarioId);
            builder.Entity<Carro>().Property( car => car.Itens).HasConversion(
                c => string.Join(',', c),
                c => c.Split(',', StringSplitOptions.RemoveEmptyEntries)
            );
            builder.Entity<Motocicleta>().HasKey( mot => mot.UsuarioId);
            builder.Entity<Motocicleta>().Property( car => car.Itens).HasConversion(
                c => string.Join(',', c),
                c => c.Split(',', StringSplitOptions.RemoveEmptyEntries)
            );
        }

    }
}