using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class EstadoCitaMutationResolver
    {
        [GraphQLDescription("Crear nuevo Estado de cita")]
        public async Task<estadoCita> crearEstadoCita(
            [Service] nancuranaisaDbContext _context,
            estadoCita estadoCitaInput
        )
        {
            _context.estadoCita.Add(estadoCitaInput);
            await _context.SaveChangesAsync();

            return estadoCitaInput;
        }

        [GraphQLDescription("Eliminar estado de cita")]
        public async Task<List<int>> eliminarEstadoCita(
            [Service] nancuranaisaDbContext _context,
            List<int> idEstadosCita
        )
        {
            List<int> deletedEstadosCita = new List<int>();
            foreach(int idEstadoCita in idEstadosCita)
            {
                var result = await _context.estadoCita.SingleOrDefaultAsync(
                        e => e.idEstado == idEstadoCita
                );

                if (result != null)
                {
                    _context.estadoCita.Remove(result);
                    deletedEstadosCita.Add(idEstadoCita);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new GraphQLException(
                        new Error("Estado de cita no encontrado")
                    );
                }
            }

            return deletedEstadosCita;
        }

        [GraphQLDescription("Actualizar Estado de cita")]
        public async Task<estadoCita> actualizarEstadoCita(
            [Service] nancuranaisaDbContext _context,
            estadoCita estadoCitaInput
        )
        {
            _context.estadoCita.Update(estadoCitaInput);
            await _context.SaveChangesAsync();
            return estadoCitaInput;

        }
    }
}
