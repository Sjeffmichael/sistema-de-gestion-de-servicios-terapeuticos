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
            TerapeutaInput terapeutaInput
        )
        {
            //List<int> diasLibres = terapeutaInput.dias
            //masajista.foto = await SaveImage(masajista.fotoPerfil);
            List<terapia> terapias = _context.terapia.Where(
                    t => terapeutaInput.terapias.Contains((int)t.idTerapia)).ToList();
            terapeuta terapeuta = new terapeuta()
            {
                idSucursal = terapeutaInput.idSucursal,
                horaEntrada = terapeutaInput.horaEntrada,
                horaSalida = terapeutaInput.horaSalida,
                idUsuario = terapeutaInput.idUsuario,
                diaLibre = terapeutaInput.diasLibres,
                idTerapia = terapias

            };

            _context.terapeuta.Add(terapeuta);
            await _context.SaveChangesAsync();

            return terapeuta;
          
        }


        [GraphQLDescription("Actualizar terapueta")]
        public async Task<terapeuta> actualizarTerapeuta(
            [Service] nancuranaisaDbContext _context,
            TerapeutaInput terapeutaInput
        )
        {
            await _context.Database.ExecuteSqlRawAsync(
                "DELETE diaLibre WHERE idTerapeuta = {0}",
                terapeutaInput.idTerapeuta
            );

            await _context.Database.ExecuteSqlRawAsync(
                "DELETE terapiaTerapeuta WHERE idTerapeuta = {0}",
                terapeutaInput.idTerapeuta
            );

            List<terapia> terapias = _context.terapia.Where(
                    t => terapeutaInput.terapias.Contains((int)t.idTerapia)).ToList();
            terapeuta terapeuta = new terapeuta()
            {
                idTerapeuta = terapeutaInput.idTerapeuta,
                idSucursal = terapeutaInput.idSucursal,
                horaEntrada = terapeutaInput.horaEntrada,
                horaSalida = terapeutaInput.horaSalida,
                idUsuario = terapeutaInput.idUsuario,
                diaLibre = terapeutaInput.diasLibres,
                idTerapia = terapias

            };
            _context.terapeuta.Update(terapeuta);
            await _context.SaveChangesAsync();
            return terapeuta;

        }
    }
}
