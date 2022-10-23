using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class UsuarioQueryResolver
    {
        [GraphQLDescription("Obtener lista de usuarios")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<usuario> GetUsuarios(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.usuario.AsQueryable();
        }
    }
}
