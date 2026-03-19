using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Infraestructura.Interfaces;
using AbonadosMunicipio.Infraestructura.DataBase;
using Microsoft.EntityFrameworkCore;


namespace AbonadosMunicipio.Infraestructura.Repositorios
{
    public class AbonadosRepositorio : IdAbonadosRepositorio
    {

        private readonly AbonadosDbContext _AbonadosDbContext;

        public AbonadosRepositorio(AbonadosDbContext abonadosDbContext)
        {
            this._AbonadosDbContext = abonadosDbContext;
        }

        public async Task ActualizarAbonado(Abonados abonado)
        {
            // Encontrar registro existente
            Abonados abonadoExistente =
                _AbonadosDbContext._Abonados
                .FirstOrDefault(x => x.Id == abonado.Id)!;

            abonadoExistente.NombreCompleto = abonado.NombreCompleto;
            abonadoExistente.Direccion = abonado.Direccion;
            abonadoExistente.NumeroMedidor = abonado.NumeroMedidor;
            abonadoExistente.ConsumoMensual = abonado.ConsumoMensual;
            abonadoExistente.TipoServicioId = abonado.TipoServicioId;

            await _AbonadosDbContext.SaveChangesAsync();
        }

        public async Task AgregarAbonado(Abonados abonado)
        {
            _AbonadosDbContext._Abonados.Add(abonado);
            await _AbonadosDbContext.SaveChangesAsync();
        }

        public async Task EliminarAbonado(int id)
        {
            // Buscamos el abonado
            var abonadoExistente = await _AbonadosDbContext._Abonados
                .FirstOrDefaultAsync(x => x.Id == id);

            if (abonadoExistente != null)
            {
                // Usamos Remove para borrarlo de la tabla
                _AbonadosDbContext._Abonados.Remove(abonadoExistente);
                await _AbonadosDbContext.SaveChangesAsync();
            }
        }

        public async Task<Abonados> ObtenerAbonadoPorId(int id)
        {
            Abonados? abonado =
                await _AbonadosDbContext._Abonados.FirstOrDefaultAsync(x => x.Id == id);

            return abonado ?? new Abonados();
        }

        public async Task<List<Abonados>> ObtenerAbonados()
        {
            return await _AbonadosDbContext._Abonados.ToListAsync();
        }
    }
}
