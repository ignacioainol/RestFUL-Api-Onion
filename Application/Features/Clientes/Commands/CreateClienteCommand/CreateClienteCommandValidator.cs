using FluentValidation;

namespace Application.Features.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Apellido)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(9).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .EmailAddress().WithMessage("{PropertyName} debe tener formato de email")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");


        }
    }
}
