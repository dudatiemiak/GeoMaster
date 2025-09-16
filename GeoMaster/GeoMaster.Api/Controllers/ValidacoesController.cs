using GeoMaster.Application.Interfaces;
using GeoMaster.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using GeoMaster.Api.DTOs;

namespace GeoMaster.GeoMaster.Api.Controllers
{
    using System.Text.RegularExpressions;
    using System.Text;
    using GeoMaster.Application.Interfaces;
    using global::GeoMaster.GeoMaster.Api.DTOs;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/validacoes")]
    public class ValidacoesController : ControllerBase
    {
        private readonly IFormaContidaService _formaContidaService;

        public ValidacoesController(IFormaContidaService formaContidaService)
        {
            _formaContidaService = formaContidaService;
        }

        /// <summary>
        /// Verifica se a forma interna pode ser contida dentro da forma externa.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST /api/v1/validacoes/forma-contida
        ///     {
        ///       "formaInterna": { "tipo": "circulo", "raio": 5 },
        ///       "formaExterna": { "tipo": "retangulo", "largura": 10, "altura": 10 }
        ///     }
        ///
        /// </remarks>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public IActionResult VerificarFormaContida([FromBody] VerificarFormaContidaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var interna = CriarForma(request.FormaInterna);
            var externa = CriarForma(request.FormaExterna);

            if (interna == null || externa == null)
                return BadRequest("Tipo de forma não suportado.");

            var resultado = _formaContidaService.VerificarContencao(interna, externa);
            return Ok(resultado);
        }


        private object? CriarForma(FormaRequestDto dto)
        {

            switch (dto.Tipo.ToLower())
            {
                case "circulo":
                    return dto.Raio.HasValue ? new Circulo(dto.Raio.Value) : null;
                case "retangulo":
                    return (dto.Largura.HasValue && dto.Altura.HasValue) ? new Retangulo(dto.Largura.Value, dto.Altura.Value) : null;
                case "esfera":
                    return dto.Raio.HasValue ? new Esfera(dto.Raio.Value) : null;
                default:
                    return null;
            }
        }

        
    }
}
