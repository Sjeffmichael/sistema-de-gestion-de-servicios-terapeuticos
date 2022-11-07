using api_nancurunaisa.Data;

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
        public IQueryable<terapeuta> GetTerapeutas(
            [Service] nancuranaisaDbContext context,
            string nombreUsuario = ""
        ) 
        {
            return context.terapeuta
                          .Where(
                            t => (
                                t.idUsuarioNavigation.nombres + ' ' + t.idUsuarioNavigation.apellidos
                            ).Contains(nombreUsuario)
                          )
                          .AsQueryable();
        } 
    }
}
