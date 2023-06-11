using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class HabitacionMutationResolver
    {
        [GraphQLDescription("Crear nueva habitación")]
        public async Task<habitacion> crearHabitacion(
            [Service] nancuranaisaDbContext _context,
            habitacion habitacionInput
        )
        {
            _context.habitacion.Add(habitacionInput);
            await _context.SaveChangesAsync();

            return habitacionInput;
        }

        [GraphQLDescription("Actualizar estado de habitación")]
        public async Task<List<habitacion>> actualizarEstadoHabitacion(
            [Service] nancuranaisaDbContext _context,
            List<int> idHabitaciones,
            bool activo
        )
        {
            List<habitacion> habitaciones = new List<habitacion>();
            foreach (int idHabitacion in idHabitaciones)
            {
                var result = await _context.habitacion.SingleOrDefaultAsync(
                    m => m.idHabitacion == idHabitacion
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    habitaciones.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Habitación no encontrada")
                    );
                }
            }
            return habitaciones;
        }

        [GraphQLDescription("Actualizar habitación")]
        public async Task<habitacion> actualizarHabitacion(
            [Service] nancuranaisaDbContext _context,
            habitacion habitacionInput
        )
        {
            _context.habitacion.Update(habitacionInput);
            await _context.SaveChangesAsync();
            return habitacionInput;

        }
    }
}
