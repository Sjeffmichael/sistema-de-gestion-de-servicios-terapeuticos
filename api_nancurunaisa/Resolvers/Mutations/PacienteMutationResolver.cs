using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class PacienteMutationResolver
    {
        [GraphQLDescription("Crear nuevo Paciente")]
        public async Task<paciente> crearPaciente(
            [Service] nancuranaisaDbContext _context,
            paciente pacienteInput
        )
        {
            _context.paciente.Add(pacienteInput);
            await _context.SaveChangesAsync();

            return pacienteInput;
        }

        [GraphQLDescription("Actualizar estado de Paciente")]
        public async Task<List<paciente>> actualizarEstadoPaciente(
            [Service] nancuranaisaDbContext _context,
            List<int> idPacientes,
            bool activo
        )
        {
            List<paciente> pacientes = new List<paciente>();
            foreach (int idPaciente in idPacientes)
            {
                var result = await _context.paciente.SingleOrDefaultAsync(
                    m => m.idPaciente == idPaciente
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    pacientes.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Pacient no encontrado")
                    );
                }
            }
            return pacientes;
        }

        [GraphQLDescription("Actualizar Paciente")]
        public async Task<paciente> actualizarPaciente(
            [Service] nancuranaisaDbContext _context,
            paciente pacienteInput
        )
        {
            _context.paciente.Update(pacienteInput);
            await _context.SaveChangesAsync();
            return pacienteInput;

        }
    }
}
