using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SucursalMutationResolver
    {
        [GraphQLDescription("Crear nueva sucursal")]
        public async Task<sucursal> crearSucursal(
            [Service] nancuranaisaDbContext _context,
            sucursal sucursalInput
        )
        {
            _context.sucursal.Add(sucursalInput);
            await _context.SaveChangesAsync();

            return sucursalInput;
        }

        [GraphQLDescription("Actualizar estado de sucursal")]
        public async Task<List<sucursal>> actualizarEstadoSucursal(
            [Service] nancuranaisaDbContext _context,
            List<int> idSucursales,
            bool activo
        )
        {
            List<sucursal> sucursales = new List<sucursal>();
            foreach (int idModulo in idSucursales)
            {
                var result = await _context.sucursal.SingleOrDefaultAsync(
                    m => m.idSucursal == idModulo
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    sucursales.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Sucursal no encontrado")
                    );
                }
            }
            return sucursales;
        }

        [GraphQLDescription("Actualizar sucursal")]
        public async Task<sucursal> actualizarSucursal(
            [Service] nancuranaisaDbContext _context,
            sucursal sucursalInput
        )
        {
            _context.sucursal.Update(sucursalInput);
            await _context.SaveChangesAsync();
            return sucursalInput;

        }
    }
}
