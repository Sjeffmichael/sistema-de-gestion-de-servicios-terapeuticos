using api_nancurunaisa.Data;
using Newtonsoft.Json;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class CitaQueryResolver
    {
        [GraphQLDescription("Obtener lista de Citas")]
        //[UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<cita>> GetCitas(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.cita.AsQueryable();
        }
        //[GraphQLDescription("Obtener lista de Citas por año y mes")]
        //public async Task<Dictionary<int, List<cita>>?> GetCitas(
        //    [Service] nancuranaisaDbContext context,
        //    string year,
        //    string month
        //)
        //{

        //    var citas = (from c in await context.cita
        //                 .Where(c => c.fechaHora.Year == Convert.ToInt32(year)
        //                 && c.fechaHora.Month == Convert.ToInt32(month)).ToListAsync()
        //                 orderby c.fechaHora
        //                 group c by c.fechaHora.Day into nc
        //                 select nc).ToDictionary(p => p.Key, p => p.ToList());

        //    return citas;
        //}
    }
}
