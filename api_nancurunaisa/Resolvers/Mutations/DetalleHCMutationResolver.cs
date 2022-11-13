using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class DetalleHCMutationResolver
    {
        [GraphQLDescription("Crear nuevo Detalle de Historal Clínico")]
        public async Task<detalleHC> crearDetalleHC(
           [Service] nancuranaisaDbContext _context,
           detalleHC detalleHCInput
       )
        {
            _context.detalleHC.Add(detalleHCInput);
            await _context.SaveChangesAsync();

            return detalleHCInput;
        }

        [GraphQLDescription("Eliminar Detalle de Historial Clínico")]
        public async Task<List<int>> eliminarDetalleHC(
            [Service] nancuranaisaDbContext _context,
            List<int> idDetalles
        )
        {
            List<int> deletedDetalleHC = new List<int>();
            foreach (int idDetalle in idDetalles)
            {
                var result = await _context.detalleHC.SingleOrDefaultAsync(
                        e => e.idDetalle == idDetalle
                );

                if (result != null)
                {
                    _context.detalleHC.Remove(result);
                    deletedDetalleHC.Add(idDetalle);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new GraphQLException(
                        new Error("Detalle de Historial Clínico no encontrado")
                    );
                }
            }

            return deletedDetalleHC;
        }

        [GraphQLDescription("Actualizar Detalle de Historial Clínico")]
        public async Task<detalleHC> actualizarDetalleHC(
            [Service] nancuranaisaDbContext _context,
            detalleHC detalleHCInput
        )
        {
            _context.detalleHC.Update(detalleHCInput);
            await _context.SaveChangesAsync();
            return detalleHCInput;

        }
    }
}
