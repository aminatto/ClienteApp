﻿using ClienteApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

    }
}