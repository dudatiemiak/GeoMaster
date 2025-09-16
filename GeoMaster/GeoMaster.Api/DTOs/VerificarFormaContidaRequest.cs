using System.ComponentModel.DataAnnotations;
using GeoMaster.Api.DTOs;

namespace GeoMaster.GeoMaster.Api.DTOs
{
    public class VerificarFormaContidaRequest
    {
        [Required(ErrorMessage = "Forma interna é obrigatória.")]
        public FormaRequestDto FormaInterna { get; set; }
        [Required(ErrorMessage = "Forma externa é obrigatória.")]
        public FormaRequestDto FormaExterna { get; set; }
    }
}
