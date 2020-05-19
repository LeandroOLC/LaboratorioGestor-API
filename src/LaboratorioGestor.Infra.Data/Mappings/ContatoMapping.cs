using LaboratorioGestor.Domain.Contatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Mappings
{

    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Celular)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.CelularWhatApp)
             .HasColumnType("varchar(30)");

            builder.Property(c => c.DataDoCadastro)
             .HasColumnType("DateTime");

            builder.Property(c => c.Email)
             .HasColumnType("varchar(80)");

            builder.Property(c => c.Fone1)
             .HasColumnType("varchar(30)");

            builder.Property(c => c.Fone2)
             .HasColumnType("varchar(30)");

            builder.Property(c => c.TipoContato)
             .IsFixedLength()
             .HasColumnType("int");
            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);


            //builder.HasMany(e => e.Dentistas)
            // .WithOne(e => e.Contatos)
            // .HasForeignKey(e => e.IDContato);

            //builder.HasMany(e => e.Laboratorios)
            //    .WithOne(e => e.Contatos)
            //    .HasForeignKey(e => e.IDContato);

            builder.HasMany(e => e.Proteticos)
                .WithOne(e => e.Contatos)
                .HasForeignKey(e => e.IDContato);

            builder.ToTable("Contatos");
        }
    }
}
