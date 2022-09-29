using api_nancurunaisa.Utilities;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class TerapeutaMutationResolve
    {
        [GraphQLDescription("Crear nueva terapueta")]
        public async Task<masajista> crearTerapeuta(
            [Service] nancurunaisadbContext _context,
            masajista terapeuta
        )
        {
            //masajista.foto = await SaveImage(masajista.fotoPerfil);
            terapeuta.password = Encrypt.GetSHA256(terapeuta.password);

            try 
            {
                _context.masajista.Add(terapeuta);
                await _context.SaveChangesAsync();

                return terapeuta;
            }
            catch(DbUpdateException)
            {
                throw new GraphQLException(
                    new Error("Este correo ya existe, intente con otro")
                );
            }            
        }

        [GraphQLDescription("Actualizar estado de terapueta")]
        public async Task<masajista> actualizarEstadoTerapeuta(
            [Service] nancurunaisadbContext _context,
            int idMasajista,
            bool activo
        )
        {
            //masajista.foto = await SaveImage(masajista.fotoPerfil);
            var result = await _context.masajista.SingleOrDefaultAsync(
                m => m.idMasajista == idMasajista
            );

            if(result != null)
            {
                result.activo = activo;
                _context.SaveChanges();

                return result;
            }
            else
            {
                throw new GraphQLException(
                    new Error("Terapeuta no encontrada")
                );
            }
        }
    }
}
