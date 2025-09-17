using GeoMaster.Domain.Entities;
using GeoMaster.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using GeoMaster.GeoMaster.Api.DTOs;
using GeoMaster.GeoMaster.Application.Interfaces;

namespace GeoMaster.GeoMaster.Api.Controllers
{

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
        /// Exemplos de requisição:
        /// 
        ///     POST /api/v1/validacoes/forma-contida
        ///     {
        ///       "formaInterna": { "tipo": "circulo", "raio": 5 },
        ///       "formaExterna": { "tipo": "retangulo", "largura": 10, "altura": 10 }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna true ou false, indicando se a forma interna cabe dentro da externa.</response>
        /// <response code="400">Os dados informados são inválidos (ex: valores negativos, tipo de forma não suportado).</response>
        /// <response code="500">Erro interno ao processar a validação.</response>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public IActionResult VerificarFormaContida([FromBody] VerificarFormaContidaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var interna = CriarForma(request.FormaInterna);
            var externa = CriarForma(request.FormaExterna);

            if (interna == null || externa == null)
                return BadRequest("Tipo de forma não suportado.");

            bool resultado;
            try
            {
                resultado = _formaContidaService.VerificarContencao(interna, externa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao validar as formas: {ex.Message}");
            }

            if (resultado)
                return Ok("A forma interna pode ser contida dentro da forma externa.");
            else
                return Ok("A forma interna não pode ser contida dentro da forma externa.");
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
