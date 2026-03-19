using Microsoft.EntityFrameworkCore;
using AbonadosMunicipio.Enitities;

namespace AbonadosMunicipio.Infraestructura.Interfaces
{
    public interface IdAbonadosRepositorio
    {
        Task<List<Abonados>> ObtenerAbonados();
         Task<Abonados> ObtenerAbonadoPorId(int id);
         Task AgregarAbonado(Abonados abonado);
         Task ActualizarAbonado(Abonados abonado);
         Task EliminarAbonado(int id);
    }
}
