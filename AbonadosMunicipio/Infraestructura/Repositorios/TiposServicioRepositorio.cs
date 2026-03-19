using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Infraestructura.Interfaces;
using AbonadosMunicipio.Infraestructura.DataBase;
using Microsoft.EntityFrameworkCore;


namespace AbonadosMunicipio.Infraestructura.Repositorios
{
    public class TiposServicioRepositorio : IdTiposServicioRepositorio
    {
        private readonly AbonadosDbContext _AbonadosDbContext;
        public TiposServicioRepositorio(AbonadosDbContext abonadosDbContext)
        {
            this._AbonadosDbContext = abonadosDbContext;
        }

        public async Task AgregarTipoServicio(TiposServicio tipoServicio)
        {
            _AbonadosDbContext._TiposServicio.Add(tipoServicio);
            await _AbonadosDbContext.SaveChangesAsync();
        }

        public async Task ActualizarTipoServicio(TiposServicio tipoServicio)
        {
            // Encontrar registro existente
            TiposServicio tipoServicioExistente =
                _AbonadosDbContext._TiposServicio
                .FirstOrDefault(x => x.Id == tipoServicio.Id)!;
            tipoServicioExistente.Nombre = tipoServicio.Nombre;
            await _AbonadosDbContext.SaveChangesAsync();
        }

        public async Task EliminarTipoServicio(int id)
        {
            // Buscamos el tipo de servicio
            var tipoServicioExistente = await _AbonadosDbContext._TiposServicio
                .FirstOrDefaultAsync(x => x.Id == id);
            if (tipoServicioExistente != null)
            {
                // Usamos Remove para borrarlo de la tabla
                _AbonadosDbContext._TiposServicio.Remove(tipoServicioExistente);
                await _AbonadosDbContext.SaveChangesAsync();
            }
        }

        public async Task<TiposServicio> ObtenerTipoServicioPorId(int id)
        {
            TiposServicio? tipoServicio =
                await _AbonadosDbContext._TiposServicio.FirstOrDefaultAsync(x => x.Id == id);
            return tipoServicio ?? new TiposServicio();
        }

        public async Task<List<TiposServicio>> ObtenerTiposServicio()
        {
            return await _AbonadosDbContext._TiposServicio.ToListAsync();
        }
    }
}
