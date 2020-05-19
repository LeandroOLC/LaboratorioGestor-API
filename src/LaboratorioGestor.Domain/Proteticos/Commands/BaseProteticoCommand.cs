﻿using LaboratorioGestor.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Commands
{
    public class BaseProteticoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public double PercentualDaComissao { get; protected set; }
        public DateTime? DataDoCadastro { get; protected set; }
        public string CPF { get; protected set; }
        public Guid? IDContato { get; protected set; }
        public Guid? IDEndereco { get; protected set; }
    }
}
