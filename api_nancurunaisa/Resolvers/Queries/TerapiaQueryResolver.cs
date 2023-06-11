using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class TerapiaQueryResolver
    {
        [GraphQLDescription("Obtener lista de terapias")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<terapia> GetTerapia(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.terapia.AsQueryable();
        }
    }
}
