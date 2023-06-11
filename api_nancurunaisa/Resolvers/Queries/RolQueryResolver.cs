using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class RolQueryResolver
    {
        [GraphQLDescription("Obtener lista de roles")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<rol> GetRoles(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.rol.AsQueryable();
        }
    }
}
