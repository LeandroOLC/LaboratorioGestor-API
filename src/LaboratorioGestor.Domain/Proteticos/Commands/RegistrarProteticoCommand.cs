using LaboratorioGestor.Domain.Contatos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Commands
{
    public class RegistrarProteticoCommand : BaseProteticoCommand
    {
        public RegistrarProteticoCommand(
            string nome,
            double percentualDaComissao,
            DateTime? dataDoCadastro,
            string cpf,
            Guid idContato,
            RegistrarContatoCommand contato
            )
        {
            Nome = nome;
            PercentualDaComissao = percentualDaComissao;
            DataDoCadastro = dataDoCadastro;
            CPF = cpf;
            IDContato = idContato;
            Contato = contato;
        }

        public RegistrarContatoCommand Contato { get; private set; }
    }
}
