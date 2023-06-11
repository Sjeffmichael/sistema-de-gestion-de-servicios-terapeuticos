using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class PacienteQueryResolver
    {
        [GraphQLDescription("Obtener lista de pacientes")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<paciente> GetPaciente(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.paciente.AsQueryable();
        }
    }
}
