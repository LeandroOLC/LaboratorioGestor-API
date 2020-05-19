using LaboratorioGestor.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Laboratorios.Commands
{
    public class RegistrarLaboratorioCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Proprietario { get; private set; }
        public string TPO { get; private set; }
        public string Documento { get; private set; }
        public int TipoPessoa { get; private set; }
        public DateTime? DataDoCadastro { get; private set; }

        public RegistrarLaboratorioCommand(
            Guid id,
            string nome,
            string proprietario,
            string tpo,
            string documento,
            int tipoPessoa,
            DateTime? dataDoCadastro)
        {
            Id = id;
            Nome = nome;
            Proprietario = proprietario;
            TPO = tpo;
            Documento = documento;
            TipoPessoa = tipoPessoa;
            DataDoCadastro = dataDoCadastro;
        }
    }
}
