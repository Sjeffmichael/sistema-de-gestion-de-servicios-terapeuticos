using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class TerapiaMutationResolver
    {
        [GraphQLDescription("Crear nueva terapia")]
        public async Task<terapia> crearTerapia(
            [Service] nancuranaisaDbContext _context,
            terapia terapiaInput
        ) 
        {
            _context.terapia.Add(terapiaInput);
            await _context.SaveChangesAsync();

            return terapiaInput;
        }

        [GraphQLDescription("Actualizar estado de terapia")]
        public async Task<List<terapia>> actualizarEstadoTerapia(
            [Service] nancuranaisaDbContext _context,
            List<int> idTerapias,
            bool activo
        )
        {
            List<terapia> terapias = new List<terapia>();
            foreach (int idTerapia in idTerapias)
            {
                var result = await _context.terapia.SingleOrDefaultAsync(
                    m => m.idTerapia == idTerapia
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    terapias.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Modulo no encontrado")
                    );
                }
            }
            return terapias;
        }

        [GraphQLDescription("Actualizar terapia")]
        public async Task<terapia> actualizarTerapia(
            [Service] nancuranaisaDbContext _context,
            terapia terapiaInput
        )
        {
            _context.terapia.Update(terapiaInput);
            await _context.SaveChangesAsync();
            return terapiaInput;

        }
    }
}
