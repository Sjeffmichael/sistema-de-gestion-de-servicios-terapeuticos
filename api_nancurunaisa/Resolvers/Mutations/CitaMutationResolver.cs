using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class CitaMutationResolver
    {
        [GraphQLDescription("Crear nueva Cita")]
        public async Task<cita> crearCita(
            [Service] nancuranaisaDbContext _context,
            CitaInput citaInput
        )
        {

            List<paciente> pacientes = await _context.paciente.Where(
                    p => citaInput.idPacientes.Contains((int)p.idPaciente)
                ).ToListAsync();

            List<promocion> promociones = await _context.promocion.Where(
                    p => citaInput.idPromociones.Contains((int)p.idPromocion)
                ).ToListAsync();

            List<terapeuta> terapeutas = await _context.terapeuta.Where(
                    p => citaInput.idTerapeutas.Contains((int)p.idTerapeuta)
                ).ToListAsync();

            List<terapia> terapias = await _context.terapia.Where(
                    p => citaInput.idTerapias.Contains((int)p.idTerapia)
                ).ToListAsync();

            cita cita = new cita()
            {
                fechaHora = citaInput.fechaHora,
                direccionDomicilio = citaInput.direccionDomicilio,
                idHabitacion = citaInput.idHabitacion,
                idEstado = (int)citaInput.idEstado,
                horaInicio = citaInput.horaInicio,
                horaFin = citaInput.horaFin,
                idPaciente = pacientes,
                idPromocion = promociones,
                idTerapeuta = terapeutas,
                idTerapia = terapias,
            };

            _context.cita.Add(cita);
            await _context.SaveChangesAsync();

            return cita;
        }

        [GraphQLDescription("Actualizar estado de Cita")]
        public async Task<cita> actualizarEstadoDeCita(
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
                    new Error("Cita no encontrada")
                );
            }
        }


        [GraphQLDescription("Actualizar Cita")]
        public async Task<cita> actualizarCita(
            [Service] nancuranaisaDbContext _context,
            CitaInput citaInput
        )
        {
            await _context.Database.ExecuteSqlRawAsync(
                "DELETE pacienteCita WHERE idCita = {0}",
                citaInput.idCita
            );

            await _context.Database.ExecuteSqlRawAsync(
                "DELETE promocionCita WHERE idCita = {0}",
                citaInput.idCita
            );

            await _context.Database.ExecuteSqlRawAsync(
                "DELETE terapeutaCita WHERE idCita = {0}",
                citaInput.idCita
            );

            await _context.Database.ExecuteSqlRawAsync(
                "DELETE terapiaCita WHERE idCita = {0}",
                citaInput.idCita
            );

            List<paciente> pacientes = await _context.paciente.Where(
                    p => citaInput.idPacientes.Contains((int)p.idPaciente)
                ).ToListAsync();

            List<promocion> promociones = await _context.promocion.Where(
                    p => citaInput.idPromociones.Contains((int)p.idPromocion)
                ).ToListAsync();

            List<terapeuta> terapeutas = await _context.terapeuta.Where(
                    p => citaInput.idTerapeutas.Contains((int)p.idTerapeuta)
                ).ToListAsync();

            List<terapia> terapias = await _context.terapia.Where(
                    p => citaInput.idTerapias.Contains((int)p.idTerapia)
                ).ToListAsync();

            cita cita = new cita()
            {
                idCita = citaInput.idCita,
                fechaHora = citaInput.fechaHora,
                direccionDomicilio = citaInput.direccionDomicilio,
                idHabitacion = citaInput.idHabitacion,
                idEstado = (int)citaInput.idEstado,
                horaInicio = citaInput.horaInicio,
                horaFin = citaInput.horaFin,
                idPaciente = pacientes,
                idPromocion = promociones,
                idTerapeuta = terapeutas,
                idTerapia = terapias,
            };

            _context.cita.Update(cita);
            await _context.SaveChangesAsync();
            return cita;

        }
    }
}
