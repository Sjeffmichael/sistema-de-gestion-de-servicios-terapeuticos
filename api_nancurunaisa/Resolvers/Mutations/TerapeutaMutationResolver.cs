using api_nancurunaisa.Data;
using api_nancurunaisa.Utilities;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class TerapeutaMutationResolver
    {
        [GraphQLDescription("Crear nueva terapueta")]
        public async Task<terapeuta> crearTerapeuta(
            [Service] nancuranaisaDbContext _context,
            terapeuta terapeutaInput
        )
        {
            //masajista.foto = await SaveImage(masajista.fotoPerfil);
            _context.terapeuta.Add(terapeutaInput);
            await _context.SaveChangesAsync();

            return terapeutaInput;
          
        }


        [GraphQLDescription("Actualizar terapueta")]
        public async Task<terapeuta> actualizarTerapeuta(
            [Service] nancuranaisaDbContext _context,
            terapeuta terapeutaInput
        )
        {
            _context.terapeuta.Update(terapeutaInput);
            await _context.SaveChangesAsync();
            return terapeutaInput;

        }
    }
}
