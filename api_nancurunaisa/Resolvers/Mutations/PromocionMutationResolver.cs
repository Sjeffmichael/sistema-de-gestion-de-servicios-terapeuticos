using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class PromocionMutationResolver
    {
        [GraphQLDescription("Crear nueva promocion")]
        public async Task<promocion> crearPromocion(
            [Service] nancuranaisaDbContext _context,
            promocion promocionInput
        )
        {
            _context.promocion.Add(promocionInput);
            await _context.SaveChangesAsync();

            return promocionInput;
        }

        [GraphQLDescription("Actualizar estado de promocion")]
        public async Task<List<promocion>> actualizarEstadoPromocion(
            [Service] nancuranaisaDbContext _context,
            List<int> idPromociones,
            bool activo
        )
        {
            List<promocion> promociones = new List<promocion>();
            foreach (int idPromocion in idPromociones)
            {
                var result = await _context.promocion.SingleOrDefaultAsync(
                    m => m.idPromocion == idPromocion
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    promociones.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Promocion no encontrado")
                    );
                }
            }
            return promociones;
        }

        [GraphQLDescription("Actualizar promocion")]
        public async Task<promocion> actualizarPromocion(
            [Service] nancuranaisaDbContext _context,
            promocion promocionInput
        )
        {
            _context.promocion.Update(promocionInput);
            await _context.SaveChangesAsync();
            return promocionInput;

        }
    }
}
