using LaboratorioGestor.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos.Commands
{
    public abstract class BaseContatoCommand : Command
    {
        public Guid Id { get; set; }
        public string Fone1 { get; protected set; }
        public string Fone2 { get; protected set; }
        public string Celular { get; protected set; }
        public string CelularWhatApp { get; protected set; }
        public DateTime DataDoCadastro { get; protected set; }
        public int TipoContato { get; protected set; }
        public string Email { get; protected set; }
    }
}
