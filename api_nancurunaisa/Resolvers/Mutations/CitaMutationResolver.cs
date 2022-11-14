using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class CitaMutationResolver
    {
        [GraphQLDescription("Crear nueva Cita")]
        public async Task<cita> crearCita(
            [Service] nancuranaisaDbContext _context,
            cita citaInput
        )
        {
            _context.cita.Add(citaInput);
            await _context.SaveChangesAsync();

            return citaInput;
        }

        [GraphQLDescription("Actualizar estado de terapia")]
        public async Task<cita> actualizarEstadoCita(
            [Service] nancuranaisaDbContext _context,
            int idCita,
            int estado
        )
        {
            var result = await _context.cita.SingleOrDefaultAsync(
                    m => m.idCita == idCita
            );

            if (result != null)
            {
                result.idEstado = estado;
                _context.SaveChanges();
                return result;
            }
            else
            {
                throw new GraphQLException(
                    new Error("Modulo no encontrado")
                );
            }
        }


        [GraphQLDescription("Actualizar Cita")]
        public async Task<cita> actualizarTerapia(
            [Service] nancuranaisaDbContext _context,
            cita citaInput
        )
        {
            _context.cita.Update(citaInput);
            await _context.SaveChangesAsync();
            return citaInput;

        }
    }
}
