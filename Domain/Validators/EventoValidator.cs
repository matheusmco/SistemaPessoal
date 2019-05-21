using FluentValidation;
using SistemaPessoal.Domain.Entities;

namespace SistemaPessoal.Domain.Validators
{
    class EventoValidator : AbstractValidator<EventoEntity>
    {
        public EventoValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x));
            RuleFor(x => x.DataHora).NotNull();
        }
    }
}