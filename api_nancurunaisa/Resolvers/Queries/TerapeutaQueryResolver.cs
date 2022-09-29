namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class TerapeutaQueryResolver
    {
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<masajista> GetMasajistas([Service] nancurunaisadbContext context) =>
        //new List<masajista>().AsQueryable();
            context.masajista;
    }
}
