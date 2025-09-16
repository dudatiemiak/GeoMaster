using GeoMaster.Application.Interfaces;
using GeoMaster.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GeoMaster.GeoMaster.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeometryController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public GeometryController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        /// <summary>
        /// Calcula a área de um círculo
        /// </summary>
        /// <param name="raio">Raio do círculo</param>
        /// <returns>Área do círculo</returns>
        [HttpGet("area2d/circulo")]
        [ProducesResponseType(typeof(double), 200)]
        public ActionResult<double> AreaCirculo(double raio)
        {
            var circulo = new Circulo(raio);
            var area = _calculadoraService.CalcularArea2D(circulo);
            return Ok(area);
        }

        /// <summary>
        /// Calcula a área de um retângulo.
        /// </summary>
        /// <param name="largura">Largura do retângulo</param>
        /// <param name="altura">Altura do retângulo</param>
        /// <returns>Área do retângulo</returns>
        [HttpGet("area2d/retangulo")]
        [ProducesResponseType(typeof(double), 200)]
        public ActionResult<double> AreaRetangulo(double largura, double altura)
        {
            var retangulo = new Retangulo(largura, altura);
            var area = _calculadoraService.CalcularArea2D(retangulo);
            return Ok(area);
        }

        /// <summary>
        /// Calcula o perímetro de um círculo
        /// </summary>
        /// <param name="raio">Raio do círculo</param>
        /// <returns>Perímetro do círculo</returns>
        [HttpGet("perimetro2d/circulo")]
        [ProducesResponseType(typeof(double), 200)]
        public ActionResult<double> PerimetroCirculo(double raio)
        {
            var circulo = new Circulo(raio);
            var perimetro = _calculadoraService.CalcularPerimetro2D(circulo);
            return Ok(perimetro);
        }

        /// <summary>
        /// Calcula o perímetro de um retângulo
        /// </summary>
        /// <param name="largura">Largura do retângulo</param>
        /// <param name="altura">Altura do retângulo</param>
        /// <returns>Perímetro do retângulo</returns>
        [HttpGet("perimetro2d/retangulo")]
        [ProducesResponseType(typeof(double), 200)]
        public ActionResult<double> PerimetroRetangulo(double largura, double altura)
        {
            var retangulo = new Retangulo(largura, altura);
            var perimetro = _calculadoraService.CalcularPerimetro2D(retangulo);
            return Ok(perimetro);
        }

        /// <summary>
        /// Calcula a área superficial de uma esfera
        /// </summary>
        /// <param name="raio">Raio da esfera</param>
        /// <returns>Área superficial da esfera</returns>
        [HttpGet("area3d/esfera")]
        [ProducesResponseType(typeof(double), 200)]
        public ActionResult<double> AreaSuperficialEsfera(double raio)
        {
            var esfera = new Esfera(raio);
            var area = _calculadoraService.CalcularAreaSuperficial3D(esfera);
            return Ok(area);
        }

        /// <summary>
        /// Calcula o volume de uma esfera.
        /// </summary>
        /// <param name="raio">Raio da esfera.</param>
        /// <returns>Volume da esfera.</returns>
        [HttpGet("volume3d/esfera")]
        [ProducesResponseType(typeof(double), 200)]
        public ActionResult<double> VolumeEsfera(double raio)
        {
            var esfera = new Esfera(raio);
            var volume = _calculadoraService.CalcularVolume3D(esfera);
            return Ok(volume);
        }
    }
}
