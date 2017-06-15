using NSubstitute;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Web.Features.Vacatures;
using Sollicitatiebeheer.Web.Tests.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sollicitatiebeheer.Web.Tests.Features.Vacatures
{
    public class IndexZou
    {
        [Theory]
        [MemberData(nameof(EenLijstMetVacaturesMoetenTeruggevenMemberData))]
        public void EenLijstMetVacaturesMoetenTeruggeven(List<Vacature> vacatures, int expectedAmount)
        {            
            using (var context = new ContextBuilder().Build())
            {
                // Arrange
                context.Vacatures.Returns(vacatures.AsQueryable());
                var request = new Index.Request();
                var handler = new Index.Handler(context);

                // Act
                var actual = handler.Handle(request);

                // Assert
                Assert.Equal(expectedAmount, actual.Vacatures.Count);
            }
        }
        private static IEnumerable<object[]> EenLijstMetVacaturesMoetenTeruggevenMemberData()
        {
            yield return new object[] { new List<Vacature>(), 0 };
            yield return new object[] { new List<Vacature> { new VacatureBuilder().Build(), new VacatureBuilder().Build() }, 2 };            
        }

        [Fact]        
        public void EenLijstMetVacaturesMoetenTeruggevenGesorteerdOpVacaturenummer()
        {
            using (var context = new ContextBuilder().Build())
            {
                // Arrange
                var vacatures = new List<Vacature>
                {
                    new VacatureBuilder().MetVacaturenummer("3").Build(),
                    new VacatureBuilder().MetVacaturenummer("1").Build(),
                    new VacatureBuilder().MetVacaturenummer("2").Build(),
                };
                context.Vacatures.Returns(vacatures.AsQueryable());
                var request = new Index.Request();
                var handler = new Index.Handler(context);

                // Act
                var actual = handler.Handle(request);

                // Assert
                var expectedNumber = 1;
                foreach(var vacature in actual.Vacatures)
                {
                    Assert.Equal(expectedNumber.ToString(), actual.Vacatures.ElementAt(expectedNumber - 1).Vacaturenummer);
                    expectedNumber++;
                }
            }
        }        
    }
}
