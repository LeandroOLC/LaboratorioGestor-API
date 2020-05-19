using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Proteticos;
using LaboratorioGestor.Domain.Recebimentos;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioGestor.Domain.Servicos
{
    [NotMapped]
    public class Servico : Entity<Servico>
    {
        public DateTime DataCadastro { get; set; }
        public double? Idade { get; set; }
        public string NomePaciente { get; set; }
        public string Cor { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double? ReferenciaOS { get; set; }
        public double? Quantidade { get; set; }
        public double? Valor { get; set; }
        public string Observcao { get; set; }
        public Guid IDProduto { get; set; }
        public Guid IDProtetico { get; set; }
        public Guid IDDentista { get; set; }
        public Guid? IDCobranca { get; set; }
        public virtual Cobranca Cobrancas { get; set; }
        public virtual Dentista Dentistas { get; set; }
        public virtual Produto Produtos { get; set; }
        public virtual Protetico Proteticos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
