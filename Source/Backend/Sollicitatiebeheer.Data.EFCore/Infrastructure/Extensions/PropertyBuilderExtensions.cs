using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sollicitatiebeheer.Data.EFCore.Infrastructure.Extensions {
    /// <summary>
    /// Holds extensions methods for decorating a property with options.
    /// </summary>
    public static class PropertyBuilderExtensions {
        public static PropertyBuilder HasDefaultValueSequentialIdSql(this PropertyBuilder propertyBuilder) {
            propertyBuilder.HasDefaultValueSql("newsequentialid()");
            return propertyBuilder;
        }
    }
}
