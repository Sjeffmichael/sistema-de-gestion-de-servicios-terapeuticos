using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class EstadoCitaQueryResolver
    {
        [GraphQLDescription("Obtener lista de Estados de citas")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<estadoCita> GetEstadosCitas(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.estadoCita.AsQueryable();
        }
    }
}
