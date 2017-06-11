using Sollicitatiebeheer.Model.Vacatures;
using Xunit;

namespace Sollicitatiebeheer.Model.Tests.Vacatures {
    public class VacatureValidatorZou {
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void FoutMoetenTeruggevenWanneerVacatureNaamLeegIs(string vacatureNummer) {
            // Arrange
            var vacature = new VacatureBuilder().WithVacaturenummer(vacatureNummer).Build();
            var validator = new VacatureValidator();

            // Act
            var actual = validator.Validate(vacature);

            // Assert
            Assert.False(actual.IsValid);
            Assert.Equal(nameof(Vacature.Vacaturenummer), actual.Errors[0].PropertyName);
        }
    }
}
