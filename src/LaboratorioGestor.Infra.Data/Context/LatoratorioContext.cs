using LaboratorioGestor.Domain.Contatos;
using LaboratorioGestor.Domain.Laboratorios;
using LaboratorioGestor.Domain.Proteticos;
using LaboratorioGestor.Infra.Data.Extensions;
using LaboratorioGestor.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Context
{
    public class LatoratorioContext : DbContext
    {
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Protetico> Proteticos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(LatoratorioContext).Assembly);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.AddConfiguration(new ContatoMapping());
            modelBuilder.AddConfiguration(new ProteticoMapping());
            modelBuilder.AddConfiguration(new LaboratorioMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
