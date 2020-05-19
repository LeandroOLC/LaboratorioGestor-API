using LaboratorioGestor.Domain.Laboratorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Mappings
{
    public class LaboratorioMapping : IEntityTypeConfiguration<Laboratorio>
    {
        public void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Nome)
              .HasColumnType("varchar(100)");

            builder.Property(e => e.Proprietario)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.TPO)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Documento)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.TipoPessoa)
                .HasColumnType("varchar(2)");
            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Laboratorios");
        }
    }
}
