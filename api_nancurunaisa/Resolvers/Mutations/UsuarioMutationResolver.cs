using api_nancurunaisa.Data;
using api_nancurunaisa.Utilities;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class UsuarioMutationResolver
    {
        [GraphQLDescription("Crear nuevo usuario")]
        public async Task<usuario> crearUsuario(
            [Service] nancuranaisaDbContext _context,
            usuario usuario
        )
        {
            //masajista.foto = await SaveImage(masajista.fotoPerfil);
            usuario.password = Encrypt.GetSHA256(usuario.password!);

            try
            {
                _context.usuario.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (DbUpdateException)
            {
                throw new GraphQLException(
                    new Error("Este correo ya existe, intente con otro")
                );
            }
        }


        [GraphQLDescription("Actualizar estado de usuario")]
        public async Task<List<usuario>> actualizarEstadoUsuario(
            [Service] nancuranaisaDbContext _context,
            List<int> idUsuarios,
            bool activo
        )
        {
            List<usuario> usuarios = new List<usuario>();
            //masajista.foto = await SaveImage(masajista.fotoPerfil);

            foreach (int idUsuario in idUsuarios)
            {
                var result = await _context.usuario.SingleOrDefaultAsync(
                    m => m.idUsuario == idUsuario
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    usuarios.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Usuario no encontrado")
                    );
                }
            }
            return usuarios;

        }

        [GraphQLDescription("Actualizar usuario")]
        public async Task<usuario> actualizarUsuario(
            [Service] nancuranaisaDbContext _context,
            usuario usuarioInput
        )
        {
            try
            {

                var userPassword = (from u in _context.usuario
                                where (u.idUsuario == usuarioInput.idUsuario)
                                select new
                                {
                                    password = u.password
                                }).FirstOrDefault();

                usuarioInput.password = userPassword!.password;

                _context.usuario.Update(usuarioInput);
                await _context.SaveChangesAsync();
                return usuarioInput;
            }
            catch (DbUpdateException)
            {
                throw new GraphQLException(
                    new Error("Este correo ya existe, intente con otro")
                );
            }
        }

    }
}
