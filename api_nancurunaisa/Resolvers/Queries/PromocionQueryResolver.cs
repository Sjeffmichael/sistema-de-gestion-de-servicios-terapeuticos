namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class PromocionQueryResolver
    {
        [GraphQLDescription("Obtener lista de promociones")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<promocion> GetPromocion(
            [Service] nancurunaisadbContext context
        )
        {
            return context.promocion.AsQueryable();
        }
    }
}
