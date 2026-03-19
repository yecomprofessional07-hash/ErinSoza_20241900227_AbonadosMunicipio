using AbonadosMunicipio.Enitities;

namespace AbonadosMunicipio.Features.Abonado.Interfaces
{
    public interface IdTiposServicioAppService
    {
        Task<List<TiposServicio>> ObtenerTiposServicio();
         Task<TiposServicio> ObtenerTipoServicioPorId(int id);
          Task AgregarTipoServicio(TiposServicio tipoServicio);
          Task ActualizarTipoServicio(TiposServicio tipoServicio);
          Task EliminarTipoServicio(int id);
    }
}
