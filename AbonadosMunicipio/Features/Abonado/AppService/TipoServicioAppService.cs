using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Features.Abonado.Interfaces;
using AbonadosMunicipio.Infraestructura.Interfaces;

namespace AbonadosMunicipio.Features.Abonado.AppService
{
    public class TipoServicioAppService : IdTiposServicioAppService
    {
        private readonly IdTiposServicioRepositorio _tiposServicioRepositorio;
        public TipoServicioAppService(IdTiposServicioRepositorio tiposServicioRepositorio)
        {
            _tiposServicioRepositorio = tiposServicioRepositorio;
        }
        public async Task AgregarTipoServicio(TiposServicio tipoServicio)
        {
            await _tiposServicioRepositorio.AgregarTipoServicio(tipoServicio);
        }
        public async Task ActualizarTipoServicio(TiposServicio tipoServicio)
        {
            await _tiposServicioRepositorio.ActualizarTipoServicio(tipoServicio);
        }
        public async Task EliminarTipoServicio(int id)
        {
            await _tiposServicioRepositorio.EliminarTipoServicio(id);
        }
        public async Task<TiposServicio> ObtenerTipoServicioPorId(int id)
        {
            return await _tiposServicioRepositorio.ObtenerTipoServicioPorId(id);
        }
        public async Task<List<TiposServicio>> ObtenerTiposServicio()
        {
            return await _tiposServicioRepositorio.ObtenerTiposServicio();
        }
    }
}
