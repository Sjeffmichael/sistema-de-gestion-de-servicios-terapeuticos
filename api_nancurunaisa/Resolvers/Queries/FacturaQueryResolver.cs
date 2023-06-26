using api_nancurunaisa.Data;
using api_nancurunaisa.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api_nancurunaisa.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class FacturaQueryResolver
    {
        [GraphQLDescription("Obtener lista de Facturas")]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<factura> GetFacturas(
            [Service] nancuranaisaDbContext context
        )
        {
            return context.factura.AsQueryable();
        }
        public class TotalResult
        {
            public decimal Total { get; set; }
        }

        [GraphQLDescription("Obtener el total a pagar en una cita")]
        public async Task<double> GetTotalFactura(
            [Service] nancuranaisaDbContext context, int idCita 
        )
        {
            double total = 0;
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $@"SELECT
                CASE
                    WHEN c.direccionDomicilio != '' THEN SUM(t.precioDomicilio)
                    ELSE SUM(t.precioLocal)
                END total
                FROM dbo.cita c
                INNER JOIN dbo.terapiaCita tC on c.idCita = tC.idCita
                INNER JOIN dbo.terapia t on t.idTerapia = tC.idTerapia
                WHERE c.idCita = {idCita}
                GROUP BY c.direccionDomicilio
                ";

                await context.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    if (await result.ReadAsync())
                    {
                        total = result.GetDouble(0);
                    }
                }
            }
            return total;
        }
    }
}
