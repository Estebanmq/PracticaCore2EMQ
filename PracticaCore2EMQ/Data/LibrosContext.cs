﻿using Microsoft.EntityFrameworkCore;
using PracticaCore2EMQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Data
{
    public class LibrosContext : DbContext
    {


        public LibrosContext(DbContextOptions<LibrosContext>options):base(options) { }


        public DbSet<Genero> Genero { get; set; }

        public DbSet<Libro> Libros { get; set; }
        
        
        public DbSet<Pedido> Pedidos { get; set; }


        public DbSet<Usuario> Usuarios { get; set; }


        public DbSet<VistaPedidos>VistaPedidos { get; set; }
    }
}
