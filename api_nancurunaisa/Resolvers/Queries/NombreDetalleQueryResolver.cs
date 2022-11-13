using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class NombreDetalleQueryResolver
    {
        [GraphQLDescription("Obtener lista de nombres de detalle")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<nombreDetalle> GetNombreDetalle(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.nombreDetalle.AsQueryable();
        }
    }
}
