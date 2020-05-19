using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaboratorioGestor.Domain.Recebimentos
{
    [NotMapped]
    public class Cobranca : Entity<Cobranca>
    {
        public DateTime DataCadastro { get; set; }

        public double? ValorDesconto { get; set; }

        public double? ValorAcrecimo { get; set; }

        public double? ValorTotal { get; set; }

        public Guid? IDDentista { get; set; }

        public double? ValorRecebimento { get; set; }

        public double? ValorRestante { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }

        public virtual ICollection<Recebimento> Recebimentos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
