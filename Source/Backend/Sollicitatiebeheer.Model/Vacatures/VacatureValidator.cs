using FluentValidation;

namespace Sollicitatiebeheer.Model.Vacatures {
    public sealed class VacatureValidator : AbstractValidator<Vacature> {
        public VacatureValidator() {
            RuleFor(v => v.Naam).NotEmpty();
        }
    }
}