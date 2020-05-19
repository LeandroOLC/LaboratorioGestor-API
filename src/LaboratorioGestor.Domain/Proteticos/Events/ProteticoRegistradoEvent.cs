using LaboratorioGestor.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Events
{
    public class ProteticoRegistradoEvent : BaseProteticoEvent
    {
        public ProteticoRegistradoEvent(
            Guid id,
            string nome,
            double percentualDaComissao,
            DateTime? dataDoCadastro,
            string cpf,
            Guid? idContato)
        {
            Id = id;
            Nome = nome;
            PercentualDaComissao = percentualDaComissao;
            DataDoCadastro = dataDoCadastro;
            CPF = cpf;
            IDContato = idContato;
            AggregateId = id;
        }
    }
}
