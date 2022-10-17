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
            [Service] nancurunaisadbContext context
        )
        {
            return context.paciente.AsQueryable();
        }
    }
}
