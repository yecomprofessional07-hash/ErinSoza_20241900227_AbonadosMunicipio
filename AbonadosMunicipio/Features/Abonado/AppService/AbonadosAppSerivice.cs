using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Commons.Models;
using AbonadosMunicipio.Features.Abonado.Datos;
using AbonadosMunicipio.Features.Abonado.DomainService;
using AbonadosMunicipio.Features.Abonado.Interfaces;
using AbonadosMunicipio.Infraestructura.Interfaces;


namespace AbonadosMunicipio.Features.Abonado.AppService
{
    public class AbonadosAppSerivice
    {
        private readonly IdAbonadosRepositorio _abonadosRepository;
        private readonly IdTiposServicioRepositorio _tiposServicio;
        private readonly AbonadosDomainService _abonadosDomainService;
        public AbonadosAppSerivice(IdAbonadosRepositorio abonadosRepository, AbonadosDomainService abonadosDomainService, IdTiposServicioRepositorio tiposServicio)
        {
            _abonadosRepository = abonadosRepository;
            _tiposServicio = tiposServicio;
            _abonadosDomainService = abonadosDomainService;
            
        }
        public async Task ActualizarAbonados(Abonados abonados)
        {
            await _abonadosRepository.ActualizarAbonado(abonados);
            
        }
        
        public async Task<ApiReponse<Abonados>> AgregarAbonado(Abonados abonados)
        {
            ApiReponse<Abonados> response = _abonadosDomainService.ValidarAbonado(abonados);
            try 
            {
                if (response.Success)
                {
                    await _abonadosRepository.AgregarAbonado(abonados);
                    response.Message = "Abonado agregado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error al agregar el abonado: {ex.Message}";
            }
            return response;
        }
        
        public async Task EliminarAbonado(int id)
        {
            await _abonadosRepository.EliminarAbonado(id);
        }

        public async Task<Abonados> ObtenerAbonadoPorId(int id)
        {
            return await _abonadosRepository.ObtenerAbonadoPorId(id);
        }

        //Metodo para listar los abonados

        public async Task<List<Abonados>> ObtenerAbonados()
        {
            return await _abonadosRepository.ObtenerAbonados();
        }

        public async Task<List<AbonadoDatos>> ObtenerAbonadosConTipoServicio()
        {
            List<Abonados> abonados = await _abonadosRepository.ObtenerAbonados();
            List<TiposServicio> tiposServicio = await _tiposServicio.ObtenerTiposServicio();
            var abonadosConTipoServicio = (
                from p in abonados
                join c in tiposServicio on p.TipoServicioId equals c.Id
                select new AbonadoDatos
                {
                    NombreCompleto = p.NombreCompleto,
                    Direccion = p.Direccion,
                    NumeroMedidor = p.NumeroMedidor,
                    ConsumoMensual = p.ConsumoMensual,
                    TipoServicioId = c.Id
                }
            ).ToList();
            return abonadosConTipoServicio;
        }
    }
}
