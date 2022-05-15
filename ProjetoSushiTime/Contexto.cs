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

        public DbSet<Produto> PRODUTOS { get; set; }
    }
}
