using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class OperacionQueryResolver
    {
        [GraphQLDescription("Obtener lista de operaciones")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<operacion> GetOperaciones(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.operacion.AsQueryable();
        }
    }
}
