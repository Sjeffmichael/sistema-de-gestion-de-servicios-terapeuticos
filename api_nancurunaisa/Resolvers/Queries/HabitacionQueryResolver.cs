using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class HabitacionQueryResolver
    {
        [GraphQLDescription("Obtener lista de habitaciones")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<habitacion> GetHabitaciones(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.habitacion.AsQueryable();
        }
    }
}
