using HotChocolate.Types;
using HotChocolate.Types.Pagination;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class TerapeutaQueryResolver
    {
        [GraphQLDescription("Obtener lista de terapeutas")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<masajista> GetMasajistas(
            [Service] nancurunaisadbContext context
        ) 
        {
            return context.masajista.AsQueryable();
        } 
    }
}
