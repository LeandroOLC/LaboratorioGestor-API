using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Proteticos;
using LaboratorioGestor.Domain.Servicos;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioGestor.Domain.Recebimentos
{
    [NotMapped]
    public class Recebimento : Entity<Recebimento>
    {
        public DateTime DataCadastro { get; set; }
        public int TipoRecebimento { get; set; }
        public double Valor { get; set; }
        public Guid IDCobranca { get; set; }
        public Guid IDProtetico { get; set; }
        public Cobranca Cobrancas { get; set; }
        public Protetico Proteticos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
