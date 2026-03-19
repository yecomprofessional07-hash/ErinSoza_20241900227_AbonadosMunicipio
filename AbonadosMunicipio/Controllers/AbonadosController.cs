using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AbonadosMunicipio.Infraestructura.Interfaces;
using AbonadosMunicipio.Enitities;
using AbonadosMunicipio.Features.Abonado.Datos;
using AbonadosMunicipio.Features.Abonado.Interfaces;

namespace AbonadosMunicipio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonadosController : ControllerBase
    {
        private readonly IdAbonadosAppService _abonadosAppService;

        public AbonadosController(IdAbonadosAppService abonadosAppService)
        {
            this._abonadosAppService = abonadosAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerAbonados()
        {
            List<Abonados> abonados = await _abonadosAppService.ObtenerAbonados();
            return Ok(abonados);
        }

        [HttpGet]
        [Route("ObtenerAbonadosConTipoServicio")]
        public async Task<IActionResult> ObtenerAbonadosConTipoServicio()
        {
            List<AbonadoDatos> abonados = await _abonadosAppService.ObtenerAbonadosConTipoServicio();
            return Ok(abonados);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerAbonadoPorId(int id)
        {
            Abonados abonado = await _abonadosAppService.ObtenerAbonadoPorId(id);
            if (abonado.Id == 0)
            {
                return NotFound();
            }
            return Ok(abonado);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarAbonado([FromBody]Abonados abonado)
        {
            var response = await _abonadosAppService.AgregarAbonados(abonado);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarAbonado([FromBody] Abonados abonado)
        {
            await _abonadosAppService.ActualizarAbonados(abonado);
            return Ok("Abanoado Actualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarAbonado(int id)
        {
            await _abonadosAppService.EliminarAbonado(id);
            return Ok("Abanoado Eliminado");

        }   
    }
}
