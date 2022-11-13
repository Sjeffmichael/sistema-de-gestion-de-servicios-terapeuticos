using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class NombreDetalleMutationResolver
    {
        [GraphQLDescription("Crear nueva nombre detalle")]
        public async Task<nombreDetalle> crearNombreDetalle(
            [Service] nancuranaisaDbContext _context,
            nombreDetalle nombreDetalleInput
        )
        {
            _context.nombreDetalle.Add(nombreDetalleInput);
            await _context.SaveChangesAsync();

            return nombreDetalleInput;
        }

        [GraphQLDescription("Actualizar estado de nombre detalle")]
        public async Task<List<nombreDetalle>> actualizarNombreDetalle(
            [Service] nancuranaisaDbContext _context,
            List<int> idNombresDetalle,
            bool activo
        )
        {
            List<nombreDetalle> nombresDetalle = new List<nombreDetalle>();
            foreach (int idTerapia in idNombresDetalle)
            {
                var result = await _context.nombreDetalle.SingleOrDefaultAsync(
                    m => m.idNombreDet == idTerapia
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    nombresDetalle.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Modulo no encontrado")
                    );
                }
            }
            return nombresDetalle;
        }

        [GraphQLDescription("Actualizar nombre detalle")]
        public async Task<nombreDetalle> actualizarNombreDetalle(
            [Service] nancuranaisaDbContext _context,
            nombreDetalle nombreDetalleInput
        )
        {
            _context.nombreDetalle.Update(nombreDetalleInput);
            await _context.SaveChangesAsync();
            return nombreDetalleInput;

        }
    }
}
