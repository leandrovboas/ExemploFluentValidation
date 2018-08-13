using AspNetCore.FluentValidation.ViewModels;
using FluentValidation;
using System;

namespace AspNetCore.FluentValidation.ViewModelValidators
{
    public class ClienteVMValidator : AbstractValidator<ClienteVM>
    {
        public ClienteVMValidator()
        {
            //Aqui adicionamos as regraas de validações do model
            RuleFor(x => x.Nome)
               .Cascade(CascadeMode.StopOnFirstFailure) //Se o validador NotEmpty falhar, o validador Length não será executado.
               .NotEmpty().WithMessage("O campo '{PropertyName}' deve ser informado")
               .Length(1, 100).WithMessage("O campo '{PropertyName}' deve ter entre 1 e 100 caracteres");

            RuleFor(x => x.SobreNome)
               .Cascade(CascadeMode.StopOnFirstFailure) //Se o validador NotEmpty falhar, o validador Length não será executado.
               .NotEmpty().WithMessage("O campo '{PropertyName}' deve ser informado")
               .Length(1, 50).WithMessage("O campo '{PropertyName}' deve ter entre 1 e 200 caracteres");

            RuleFor(c => c.Email)
             .Cascade(CascadeMode.StopOnFirstFailure) //Se o validador NotEmpty falhar, o validador EmailAddress não será executado.
             .NotEmpty().WithMessage("O campo '{PropertyName}' deve ser informado")
             .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(c => c.DataNascimento)
             .Cascade(CascadeMode.StopOnFirstFailure) //Se o validador NotEmpty falhar, o validador Must não será executado.
             .NotEmpty().WithMessage("O campo '{PropertyName}' deve ser informado")
             .Must(ClienteMaiorDeIdade).WithMessage("O cliente deve ter no mínimo 18 anos");

        }

        //Aqui criamos uma validação customizada basuca para servir de exemplo
        private static bool ClienteMaiorDeIdade(DateTime dataNascimento) =>
            dataNascimento <= DateTime.Now.AddYears(-18);
    }
}
