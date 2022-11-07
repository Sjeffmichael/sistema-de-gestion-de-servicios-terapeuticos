using api_nancurunaisa.Data;
using System.Linq;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class RolMutationResolver
    {
        [GraphQLDescription("Crear nuevo rol")]
        public async Task<rol> crearRol(
            [Service] nancuranaisaDbContext _context,
            RolIntpu rolInput
        )
        {
            // obtener lista de operaciones que se desean agregar
            List<operacion> operaciones = _context.operacion.Where(
                                          o => rolInput.operaciones.Contains((int)o.idOperacion)).ToList();

            rol rol = new rol() 
            {
                nombreRol = rolInput.nombreRol,
                descripcion = rolInput.descripcion,
                idOperacion = operaciones

            };

            _context.rol.Add(rol);
            await _context.SaveChangesAsync();

            return rol;
        }

        [GraphQLDescription("Actualizar estado de rol")]
        public async Task<List<rol>> actualizarEstadoRol(
            [Service] nancuranaisaDbContext _context,
            List<int> idRoles,
            bool activo
        )
        {
            List<rol> roles = new List<rol>();
            foreach (int idRol in idRoles)
            {
                var result = await _context.rol.SingleOrDefaultAsync(
                    m => m.idRol == idRol
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    roles.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Rol no encontrado")
                    );
                }
            }
            return roles;
        }

        [GraphQLDescription("Actualizar rol")]
        public async Task<rol> actualizarRol(
            [Service] nancuranaisaDbContext _context,
            RolIntpu rolInput
        )
        {
            // eliminar operaciones del rol que se desea actualizar
            var result = await _context.Database.ExecuteSqlRawAsync(
                "DELETE rolOperacion WHERE idRol = {0}",
                rolInput.idRol
            );

            // obtener lista de operaciones que se desean agregar
            List<operacion> operaciones = _context.operacion.Where(
                                          o => rolInput.operaciones.Contains((int)o.idOperacion)).ToList();

            rol rol = new rol()
            {
                idRol = rolInput.idRol,
                nombreRol = rolInput.nombreRol,
                descripcion = rolInput.descripcion,
                idOperacion = operaciones,
                activo = rolInput.activo

            };

            _context.rol.Update(rol);
            await _context.SaveChangesAsync();
            return rol;

        }
    }
}
