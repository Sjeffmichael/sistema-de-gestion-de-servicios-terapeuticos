using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class OperacionMutationResolver
    {
        [GraphQLDescription("Crear nueva operacion")]
        public async Task<operacion> crearOperacion(
            [Service] nancuranaisaDbContext _context,
            operacion operacionInput
        )
        {
            _context.operacion.Add(operacionInput);
            await _context.SaveChangesAsync();

            return operacionInput;
        }

        [GraphQLDescription("Actualizar estado de operacion")]
        public async Task<List<operacion>> actualizarEstadoOperacion(
            [Service] nancuranaisaDbContext _context,
            List<int> idOperaciones,
            bool activo
        )
        {
            List<operacion> operaciones = new List<operacion>();
            foreach (int idOperacion in idOperaciones)
            {
                var result = await _context.operacion.SingleOrDefaultAsync(
                    m => m.idOperacion == idOperacion
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    operaciones.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Operacion no encontrado")
                    );
                }
            }
            return operaciones;
        }

        [GraphQLDescription("Actualizar operación")]
        public async Task<operacion> actualizarOperacion(
            [Service] nancuranaisaDbContext _context,
            operacion operacionInput
        )
        {
            _context.operacion.Update(operacionInput);
            await _context.SaveChangesAsync();
            return operacionInput;

        }
    }
}
