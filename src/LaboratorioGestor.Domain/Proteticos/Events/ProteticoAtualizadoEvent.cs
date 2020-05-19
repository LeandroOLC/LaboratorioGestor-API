using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Events
{
    public class ProteticoAtualizadoEvent : BaseProteticoEvent
    {
        public ProteticoAtualizadoEvent(
            Guid id,
            string nome,
            double percentualDaComissao,
            DateTime? dataDoCadastro,
            string cpf)
        {
            Id = id;
            Nome = nome;
            PercentualDaComissao = percentualDaComissao;
            DataDoCadastro = dataDoCadastro;
            CPF = cpf;

            AggregateId = id;
        }

    }
}
