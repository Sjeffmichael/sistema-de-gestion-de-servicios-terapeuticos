using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class ModuloQueryResolver
    {
        [GraphQLDescription("Obtener lista de modulos")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<modulo> GetModulos(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.modulo.AsQueryable();
        }
    }
}
