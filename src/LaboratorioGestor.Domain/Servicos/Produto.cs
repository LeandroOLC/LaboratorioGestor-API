using LaboratorioGestor.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaboratorioGestor.Domain.Servicos
{
    [NotMapped]
    public class Produto : Entity<Produto>
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
