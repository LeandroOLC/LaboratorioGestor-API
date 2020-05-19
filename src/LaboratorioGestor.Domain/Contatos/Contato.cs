using FluentValidation;
using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Laboratorios;
using LaboratorioGestor.Domain.Proteticos;
using LaboratorioGestor.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos
{
    public class Contato : Entity<Contato>
    {  
        //public Guid ProteticoId { get; private set; }
        public string Fone1 { get; private set; }
        public string Fone2 { get; private set; }
        public string Celular { get; private set; }
        public string CelularWhatApp { get; private set; }
        public DateTime DataDoCadastro { get; private set; }
        public int TipoContato { get; private set; }
        public string Email { get; private set; }
        //public virtual ICollection<Dentista> Dentistas { get; private set; }
        //public virtual ICollection<Laboratorio> Laboratorios { get; private set; }
        public virtual ICollection<Protetico> Proteticos { get; private set; }

        public Contato(
            Guid id,
            string fone1,
            string fone2,
            string celular,
            string celularWhatApp,
            DateTime dataDoCadastro,
            int tipoContato,
            string email)
        {
            Id = id;
            Fone1 = fone1;
            Fone2 = fone2;
            Celular = celular;
            CelularWhatApp = celularWhatApp;
            DataDoCadastro = dataDoCadastro;
            TipoContato = tipoContato;
            Email = email;
        }

        public override bool EhValido()
        {
            RuleFor(c => c.Celular)
             .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.CelularWhatApp)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
              .Length(10, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Fone1)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Fone2)
              .Length(12, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
