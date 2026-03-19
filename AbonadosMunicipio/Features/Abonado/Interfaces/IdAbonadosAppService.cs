using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Commons.Models;
using AbonadosMunicipio.Features.Abonado.Datos;


namespace AbonadosMunicipio.Features.Abonado.Interfaces
{
    public interface IdAbonadosAppService
    {
        Task<List<Abonados>> ObtenerAbonados();
        Task<ApiReponse<Abonados>> AgregarAbonados(Abonados abonado);
        Task ActualizarAbonados(Abonados abonado);
        Task<Abonados> ObtenerAbonadoPorId(int id);
        Task EliminarAbonado(int id);
        Task<List<TiposServicio>> ObtenerTiposServicio();
        Task<List<AbonadoDatos>> ObtenerAbonadosConTipoServicio();
    }
}
