using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class DiaLibreQueryResolver
    {
        [GraphQLDescription("Obtener lista de dias libres")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<diaLibre> GetDiaLibre(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.diaLibre.AsQueryable();
        }
    }
}
