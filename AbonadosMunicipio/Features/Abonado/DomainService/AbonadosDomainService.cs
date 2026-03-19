using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Commons.Models;

namespace AbonadosMunicipio.Features.Abonado.DomainService
{
    public class AbonadosDomainService
    {
        public AbonadosDomainService() { }

        public ApiReponse<Abonados> ValidarAbonado(Abonados abonado)
        {
            ApiReponse<Abonados> response = new ApiReponse<Abonados>();
            if (string.IsNullOrEmpty(abonado.NombreCompleto))
            {
                response.Success = false;
                response.Message = "El nombre completo es obligatorio.";
                return response;
            }
            if (string.IsNullOrEmpty(abonado.Direccion))
            {
                response.Success = false;
                response.Message = "La dirección es obligatoria.";
                return response;
            }
            if (string.IsNullOrEmpty(abonado.NumeroMedidor))
            {
                response.Success = false;
                response.Message = "El número de medidor es obligatorio.";
                return response;
            }
            if (abonado.ConsumoMensual < 0)
            {
                response.Success = false;
                response.Message = "El consumo mensual no puede ser negativo.";
                return response;
            }
            if (abonado.TipoServicioId <= 0)
            {
                response.Success = false;
                response.Message = "El tipo de servicio es obligatorio.";
                return response;
            }
            // Si todas las validaciones pasan, el abonado es válido
            response.Success = true;
            response.Data = abonado;
            return response;
        }
    }
}
