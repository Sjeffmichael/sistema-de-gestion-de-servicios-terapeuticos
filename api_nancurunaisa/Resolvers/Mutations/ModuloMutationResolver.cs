using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ModuloMutationResolver
    {
        [GraphQLDescription("Crear nuevo modulo")]
        public async Task<modulo> crearModulo(
            [Service] nancuranaisaDbContext _context,
            modulo moduloInput
        )
        {
            _context.modulo.Add(moduloInput);
            await _context.SaveChangesAsync();

            return moduloInput;
        }

        [GraphQLDescription("Actualizar estado de modulo")]
        public async Task<List<modulo>> actualizarEstadoModulo(
            [Service] nancuranaisaDbContext _context,
            List<int> idModulos,
            bool activo
        )
        {
            List<modulo> modulos = new List<modulo>();
            foreach (int idModulo in idModulos)
            {
                var result = await _context.modulo.SingleOrDefaultAsync(
                    m => m.idModulo == idModulo
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    modulos.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Modulo no encontrado")
                    );
                }
            }
            return modulos;
        }

        [GraphQLDescription("Actualizar modulo")]
        public async Task<modulo> actualizarModulo(
            [Service] nancuranaisaDbContext _context,
            modulo maduloInput
        )
        {
            _context.modulo.Update(maduloInput);
            await _context.SaveChangesAsync();
            return maduloInput;

        }
    }
}
