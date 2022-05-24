using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSushiTime.Entidades;

namespace ProjetoSushiTime
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> option) : base(option) { }

        public DbSet<Cliente> CLIENTES { get; set; }

        public DbSet<Usuarios> USUARIOS { get; set; }

        public DbSet<Produtos> PRODUTOS { get; set; }
    }
}
