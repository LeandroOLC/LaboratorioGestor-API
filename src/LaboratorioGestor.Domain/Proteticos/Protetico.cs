using FluentValidation;
using LaboratorioGestor.Domain.Contatos;
using LaboratorioGestor.Domain.Core.Models;
using LaboratorioGestor.Domain.Recebimentos;
using LaboratorioGestor.Domain.Servicos;
using LaboratorioGestor.Domain.Validation;
using System;
using System.Collections.Generic;

namespace LaboratorioGestor.Domain.Proteticos
{
    public class Protetico : Entity<Protetico>
    {
        public string Nome { get; set; }
        public double PercentualDaComissao { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public string CPF { get; set; }
        public Guid? IDContato { get; set; }
 
        public Contato Contatos { get; set; }

        public override bool EhValido()
        {
            RuleFor(c => c.Nome)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(4, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.PercentualDaComissao)
              .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}")
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
              .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public static class ProteticoFactory
        {
            public static Protetico NovoProteticoCompleto(
                Guid id,
                string nome,
                double percentualDaComissao,
                DateTime? dataDoCadastro,
                string cpf,
                Guid? idContato,
                Contato contato)
            {
                var protetico = new Protetico()
                {
                    Id = id,
                    Nome = nome,
                    PercentualDaComissao = percentualDaComissao,
                    DataDoCadastro = dataDoCadastro,
                    CPF = cpf,
                    IDContato = idContato,
                    Contatos = contato
                };

                //TODO: Poderá ser adicionador as outras entidades aqui. Endereco

                return protetico;
                
            }
        }
    }
}
