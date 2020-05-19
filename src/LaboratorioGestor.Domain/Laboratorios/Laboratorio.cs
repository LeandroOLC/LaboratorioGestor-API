using FluentValidation;
using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Validation;
using System;

namespace LaboratorioGestor.Domain.Laboratorios
{
    public class Laboratorio : Entity<Laboratorio>
    {
        public string Nome { get; set; }
        public string Proprietario { get; set; }
        public string TPO { get; set; }
        public string Documento { get; set; }
        public int TipoPessoa { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        //public Guid? IDEndereco { get; set; }
        //public Guid? IDContato { get; set; }
      
        public Laboratorio(Guid id,
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

        public Laboratorio() { }

       // public virtual Contatos Contatos { get; set; }
       // public virtual Enderecos Enderecos { get; set; }

        public override bool EhValido()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Proprietario)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.TPO)
             .Length(2, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoPessoa == 1, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

            When(f => f.TipoPessoa == 2, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });


            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

    }
}
