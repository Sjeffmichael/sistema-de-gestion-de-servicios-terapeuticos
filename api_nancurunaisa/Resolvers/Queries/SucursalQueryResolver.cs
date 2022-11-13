using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class SucursalQueryResolver
    {
        [GraphQLDescription("Obtener lista de sucursales")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<sucursal> GetSucursales(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.sucursal.AsQueryable();
        }
    }
}
