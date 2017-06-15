using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Sollicitatiebeheer.Data.EFCore;
using Sollicitatiebeheer.Model.Vacatures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sollicitatiebeheer.Web.Tests.Infrastructure
{
    public class ContextBuilder
    {
        public ISollicitatiebeheerContext Build(bool inMemoryContext = false)
        {
            if (inMemoryContext)
            {
                var options = new DbContextOptionsBuilder<SollicitatiebeheerContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                return new SollicitatiebeheerContext(options);
            }
            else
            {
                var context = Substitute.For<ISollicitatiebeheerContext>();

                context.Vacatures.Returns(new List<Vacature>().AsQueryable());

                return context;
            }
        }
    }
}
