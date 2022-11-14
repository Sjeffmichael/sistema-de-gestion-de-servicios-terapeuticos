using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class CitaQueryResolver
    {
        [GraphQLDescription("Obtener lista de Citas")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<cita> GetCitas(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.cita.AsQueryable();
        }
    }
}
