using Microsoft.EntityFrameworkCore;
using AbonadosMunicipio.Enitities;

namespace AbonadosMunicipio.Infraestructura.Interfaces
{
    public interface IdTiposServicioRepositorio
    {
        Task<List<TiposServicio>> ObtenerTiposServicio();
         Task<TiposServicio> ObtenerTipoServicioPorId(int id);
          Task AgregarTipoServicio(TiposServicio tipoServicio);
          Task ActualizarTipoServicio(TiposServicio tipoServicio);
          Task EliminarTipoServicio(int id);

    }
}
