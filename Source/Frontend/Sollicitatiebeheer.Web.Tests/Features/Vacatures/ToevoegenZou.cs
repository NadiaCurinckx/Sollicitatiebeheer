using Sollicitatiebeheer.Web.Features.Vacatures;
using System;
using Xunit;

namespace Sollicitatiebeheer.Web.Tests.Features.Vacatures
{
    public class ToevoegenTests
    {
        [Fact]
        public void EenLegeVacatureMoetenTeruggeven()
        {
            // Arrange
            var expected = Guid.Empty;
            var request = new Toevoegen.Request();
            var handler = new Toevoegen.Handler();

            // Act
            var actual = handler.Handle(request);

            // Assert
            Assert.Equal(expected, actual.Vacature.Id);            
        }
    }
}
