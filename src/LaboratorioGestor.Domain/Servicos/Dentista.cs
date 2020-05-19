using LaboratorioGestor.Domain.Contatos;
using LaboratorioGestor.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaboratorioGestor.Domain.Servicos
{
    [NotMapped]
    public class Dentista : Entity<Dentista>
    {
        public string Nome { get; set; }
        public string NomeDaClinica { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public string CRO { get; set; }
        public string Documento { get; set; }
        public int TipoPessoa { get; set; }
        public Guid? IDEndereco { get; set; }
        public Guid? IDContato { get; set; }
        public virtual Contato Contatos { get; set; }
        public virtual Endereco Enderecos { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
