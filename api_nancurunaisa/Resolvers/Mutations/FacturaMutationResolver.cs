using api_nancurunaisa.Data;

namespace api_nancurunaisa.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class FacturaMutationResolver
    {
        [GraphQLDescription("Crear nueva Factura")]
        public async Task<factura> crearFactura(
            [Service] nancuranaisaDbContext _context,
            factura facturaInput
        )
        {
            _context.factura.Add(facturaInput);
            await _context.SaveChangesAsync();

            return facturaInput;
        }

        [GraphQLDescription("Actualizar estado de Factura")]
        public async Task<List<factura>> actualizarEstadoFactura(
            [Service] nancuranaisaDbContext _context,
            List<int> idFacturas,
            bool activo
        )
        {
            List<factura> facturas = new List<factura>();
            foreach (int idFactura in idFacturas)
            {
                var result = await _context.factura.SingleOrDefaultAsync(
                    m => m.idFactura == idFactura
                );

                if (result != null)
                {
                    result.activo = activo;
                    _context.SaveChanges();

                    facturas.Add(result);
                }
                else
                {
                    throw new GraphQLException(
                        new Error("Factura no encontrada")
                    );
                }
            }
            return facturas;
        }

        [GraphQLDescription("Actualizar Factura")]
        public async Task<factura> actualizarFactura(
            [Service] nancuranaisaDbContext _context,
            factura facturaInput
        )
        {
            _context.factura.Update(facturaInput);
            await _context.SaveChangesAsync();
            return facturaInput;

        }
    }
}
