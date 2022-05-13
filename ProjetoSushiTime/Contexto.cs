﻿using Microsoft.EntityFrameworkCore;
using ProjetoSushiTime.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSushiTime
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto>option):base(option)
        {}

        public DbSet<Cliente> CLIENTES { get; set; }
    }
}