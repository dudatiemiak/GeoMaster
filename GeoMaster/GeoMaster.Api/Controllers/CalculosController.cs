using GeoMaster.Application.Interfaces;
using GeoMaster.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using GeoMaster.Api.DTOs;

namespace GeoMaster.Api.Controllers
{
    [ApiController]
    [Route("api/v1/calculos")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public CalculosController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        /// <summary>
        /// Calcula a área de uma forma geométrica.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST /api/v1/calculos/area
        ///     {
        ///         "tipo": "circulo",
        ///         "raio": 5
        ///     }
        ///
        /// </remarks>
        /// <param name="dto">Objeto contendo os dados da forma geométrica.</param>
        /// <response code="200">Retorna o valor da área calculada.</response>
        /// <response code="400">Se os parâmetros forem inválidos ou a forma não suportar área.</response>
        [HttpPost("area")]
        [ProducesResponseType(typeof(double), 200)]
        [ProducesResponseType(400)]
        public IActionResult CalcularArea([FromBody] FormaRequestDto dto)
        {
            var (forma, erro) = FormaFactory(dto);
            if (erro != null) return BadRequest(erro);
            if (forma is ICalculos2D f2d)
                return Ok(_calculadoraService.CalcularArea2D(f2d));
            if (forma is ICalculos3D f3d)
                return Ok(_calculadoraService.CalcularAreaSuperficial3D(f3d));
            return BadRequest("Forma não suportada para cálculo de área.");
        }

        /// <summary>
        /// Calcula o perímetro de uma forma 2D.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST /api/v1/calculos/perimetro
        ///     {
        ///         "tipo": "retangulo",
        ///         "largura": 4,
        ///         "altura": 6
        ///     }
        ///
        /// </remarks>
        /// <param name="dto">Objeto contendo os dados da forma geométrica.</param>
        /// <response code="200">Retorna o valor do perímetro.</response>
        /// <response code="400">Se a forma não for 2D ou os parâmetros forem inválidos.</response>
        [HttpPost("perimetro")]
        [ProducesResponseType(typeof(double), 200)]
        [ProducesResponseType(400)]
        public IActionResult CalcularPerimetro([FromBody] FormaRequestDto dto)
        {
            var (forma, erro) = FormaFactory(dto);
            if (erro != null) return BadRequest(erro);
            if (forma is ICalculos2D f2d)
                return Ok(_calculadoraService.CalcularPerimetro2D(f2d));
            return BadRequest("Apenas formas 2D possuem perímetro.");
        }

        /// <summary>
        /// Calcula o volume de uma forma 3D.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST /api/v1/calculos/volume
        ///     {
        ///         "tipo": "esfera",
        ///         "raio": 3
        ///     }
        ///
        /// </remarks>
        /// <param name="dto">Objeto contendo os dados da forma geométrica.</param>
        /// <response code="200">Retorna o valor do volume.</response>
        /// <response code="400">Se a forma não for 3D ou os parâmetros forem inválidos.</response>
        [HttpPost("volume")]
        [ProducesResponseType(typeof(double), 200)]
        [ProducesResponseType(400)]
        public IActionResult CalcularVolume([FromBody] FormaRequestDto dto)
        {
            var (forma, erro) = FormaFactory(dto);
            if (erro != null) return BadRequest(erro);
            if (forma is ICalculos3D f3d)
                return Ok(_calculadoraService.CalcularVolume3D(f3d));
            return BadRequest("Apenas formas 3D possuem volume.");
        }

        private (object? forma, string? erro) FormaFactory(FormaRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Tipo))
                return (null, "Campo 'tipo' é obrigatório.");
            switch (dto.Tipo.ToLower())
            {
                case "circulo":
                    if (dto.Raio is null || dto.Raio < 0)
                        return (null, "Raio deve ser informado e não pode ser negativo.");
                    return (new Circulo(dto.Raio.Value), null);
                case "retangulo":
                    if (dto.Largura is null || dto.Largura < 0 || dto.Altura is null || dto.Altura < 0)
                        return (null, "Largura e altura devem ser informadas e não podem ser negativas.");
                    return (new Retangulo(dto.Largura.Value, dto.Altura.Value), null);
                case "esfera":
                    if (dto.Raio is null || dto.Raio < 0)
                        return (null, "Raio deve ser informado e não pode ser negativo.");
                    return (new Esfera(dto.Raio.Value), null);
                default:
                    return (null, $"Tipo de forma '{dto.Tipo}' não suportado.");
            }
        }
    }
}
