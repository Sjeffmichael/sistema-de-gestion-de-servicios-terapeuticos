using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class FacturaQueryResolver
    {
        [GraphQLDescription("Obtener lista de Facturas")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<factura> GetFacturas(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.factura.AsQueryable();
        }
    }
}
