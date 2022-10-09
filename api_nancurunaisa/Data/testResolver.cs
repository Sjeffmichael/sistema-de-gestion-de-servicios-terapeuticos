
namespace api_nancurunaisa.Data
{
    public class testResolver
    {
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<masajista> GetMasajistas([Service] nancurunaisadbContext context) =>
        //new List<masajista>().AsQueryable();
            context.masajista;

    }
}
