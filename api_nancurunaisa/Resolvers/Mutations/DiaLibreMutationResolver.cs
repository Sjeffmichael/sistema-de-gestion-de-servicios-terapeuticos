using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{

    public enum Dias
    {
        Domingo = 1,
        Lunes = 2,
        Martes = 3,
        Miercoles = 4,
        Jueves = 5,
        Viernes = 6,
        Sabado = 7,
    }

    [ExtendObjectType("Mutation")]
    public class DiaLibreMutationResolver
    {

        public async Task<diaLibre> asignarDiaLibre(
            [Service] nancuranaisaDbContext _context,
            Dias dia,
            int idTerapeuta
        )
        {
            //try
            //{

                diaLibre diaLibre = new diaLibre();
                diaLibre.idTerapeuta = idTerapeuta;
                diaLibre.idDia = (int)dia;

                _context.diaLibre.Add(diaLibre);    

                await _context.SaveChangesAsync();

                return diaLibre;
            //}
            //catch (DbUpdateException)
            //{
            //    throw new GraphQLException(
            //        new Error("Este terapeuta no existe, intente con otro")
            //    );
            //}
        }
    }
}
