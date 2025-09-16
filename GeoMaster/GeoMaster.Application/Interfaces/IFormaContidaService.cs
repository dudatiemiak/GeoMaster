using GeoMaster.GeoMaster.Domain.Entities;

namespace GeoMaster.GeoMaster.Application.Interfaces
{
    public interface IFormaContidaService
    {
        bool VerificarContencao(object formaInterna, object formaExterna);
    }
}
