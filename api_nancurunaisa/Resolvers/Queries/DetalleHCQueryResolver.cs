using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class DetalleHCQueryResolver
    {
        [GraphQLDescription("Obtener lista de Detalle de Historial Clínico")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<detalleHC> GetDetalleHC(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.detalleHC.AsQueryable();
        }
    }
}
