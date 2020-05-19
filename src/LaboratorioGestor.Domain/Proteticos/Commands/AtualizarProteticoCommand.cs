using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Commands
{
    public class AtualizarProteticoCommand : BaseProteticoCommand
    {
        public AtualizarProteticoCommand(
            string nome,
            double percentualDaComissao,
            DateTime? dataDoCadastro,
            string cpf
            )
        {
            Nome = nome;
            PercentualDaComissao = percentualDaComissao;
            DataDoCadastro = dataDoCadastro;
            CPF = cpf;
        }
    }
}
