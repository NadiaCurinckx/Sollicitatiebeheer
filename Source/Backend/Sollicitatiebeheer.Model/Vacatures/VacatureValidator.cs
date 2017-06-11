using FluentValidation;

namespace Sollicitatiebeheer.Model.Vacatures
{
    public sealed class VacatureValidator : AbstractValidator<Vacature>
    {
        public VacatureValidator()
        {
            RuleFor(v => v.Vacaturenummer).NotEmpty();
            RuleFor(v => v.Omschrijving).NotEmpty();
            RuleFor(v => v.Afdeling).NotEmpty();
            RuleFor(v => v.Functie).NotEmpty();
        }
    }
}