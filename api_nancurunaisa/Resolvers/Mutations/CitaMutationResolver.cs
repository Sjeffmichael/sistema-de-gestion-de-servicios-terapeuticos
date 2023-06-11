using api_nancurunaisa.Data;
using api_nancurunaisa.Models;
using MessagePack;
using System.Globalization;

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
            List<paciente> pacientes = new List<paciente>(); 
            List<terapeuta> terapeutas = new List<terapeuta>();
            List<promocion> promociones = new List<promocion>();
            List<terapia> terapias = new List<terapia>();

            if (citaInput.idPacientes != null)
            {
                pacientes = await _context.paciente.Where(
                        p => citaInput.idPacientes.Contains((int)p.idPaciente)
                    ).ToListAsync();

            }

            if (citaInput.idPromociones != null)
            {
                promociones = await _context.promocion.Where(
                    p => citaInput.idPromociones.Contains((int)p.idPromocion)
                ).ToListAsync();
            }

            if (citaInput.idTerapeutas != null)
            {
                terapeutas = await _context.terapeuta.Where(
                    p => citaInput.idTerapeutas.Contains((int)p.idTerapeuta)
                ).ToListAsync();
            }

            if (citaInput.idTerapias != null)
            {
                terapias = await _context.terapia.Where(
                    p => citaInput.idTerapias.Contains((int)p.idTerapia)
                ).ToListAsync();
            }

            cita cita = new cita()
            {
                fechaHora = StringToDT(citaInput.fechaHora),
                direccionDomicilio = citaInput.direccionDomicilio,
                idHabitacion = citaInput.idHabitacion,
                idEstado = (int)citaInput.idEstado,
                horaInicio = citaInput.horaInicio is not null ? StringToDT(citaInput.horaInicio) : null,
                horaFin = citaInput.horaFin is not null ? StringToDT(citaInput.horaFin) : null,
                idPaciente = pacientes,
                idPromocion = promociones,
                idTerapeuta = terapeutas,
                idTerapia = terapias,
                detalleHC = citaInput.historialClinico
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

            await _context.Database.ExecuteSqlRawAsync(
                "DELETE detalleHC WHERE idCita = {0}",
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

            var vs = DateTime.Parse(citaInput.fechaHora);


            cita cita = new cita()
            {
                idCita = citaInput.idCita,
                fechaHora = StringToDT(citaInput.fechaHora),
                direccionDomicilio = citaInput.direccionDomicilio,
                idHabitacion = citaInput.idHabitacion,
                idEstado = (int)citaInput.idEstado,
                horaInicio = citaInput.horaInicio is not null? StringToDT(citaInput.horaInicio): null,
                horaFin = citaInput.horaFin is not null ? StringToDT(citaInput.horaFin) : null,
                idPaciente = pacientes,
                idPromocion = promociones,
                idTerapeuta = terapeutas,
                idTerapia = terapias,
                detalleHC = citaInput.historialClinico
            };

            _context.cita.Update(cita);
            await _context.SaveChangesAsync();
            return cita;

        }

        public DateTime StringToDT(String date)
        {
            DateTime fechaHora = DateTime.Parse(date);
            return fechaHora;
        }
    }
}
