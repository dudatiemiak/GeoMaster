using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeoMaster.Api.DTOs
{
    [JsonConverter(typeof(FormaRequestDtoConverter))]
    public class FormaRequestDto
    {
        [Required(ErrorMessage = "O tipo da forma é obrigatório.")]
        public string Tipo { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        public double? Raio { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        public double? Largura { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "A altura deve ser maior que zero.")]
        public double? Altura { get; set; }
    }
}
