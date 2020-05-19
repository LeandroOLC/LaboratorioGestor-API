using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Laboratorios;
using LaboratorioGestor.Domain.Proteticos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioGestor.Domain.Servicos
{
    [NotMapped]
    public class Endereco : Entity<Endereco>
    {
        public Guid DentistaId { get; set; }
        public Guid LaboratorioId { get; set; }
        public Guid ProteticoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string ReferenciaDoEndereco { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public int TipoEndereco { get; set; }
        public virtual ICollection<Dentista> Dentistas { get; set; }
        public virtual ICollection<Laboratorio> Laboratorios { get; set; }
        public virtual ICollection<Protetico> Proteticos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
