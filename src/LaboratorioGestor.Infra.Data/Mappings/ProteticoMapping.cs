using LaboratorioGestor.Domain.Proteticos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Mappings
{
    public class ProteticoMapping : IEntityTypeConfiguration<Protetico>
    {
        public void Configure(EntityTypeBuilder<Protetico> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.IDContato)
            .HasColumnType("UniqueIdentifier");

            builder.Property(e => e.Nome)
            .HasColumnType("varchar(200)");

            builder.Property(e => e.CPF)
            .HasColumnType("varchar(30)");

            builder.Property(c => c.DataDoCadastro)
                    .HasColumnType("DateTime");
            
            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);


            //builder.HasMany(e => e.Servicos)
            //    .WithOne(e => e.Proteticos)
            //    .HasForeignKey(e => e.IDProtetico);

            //builder.HasMany(e => e.Recebimentos)
            // .WithOne(e => e.Proteticos)
            // .HasForeignKey(e => e.IDProtetico);

            builder.ToTable("Proteticos");
        }
    }
}
