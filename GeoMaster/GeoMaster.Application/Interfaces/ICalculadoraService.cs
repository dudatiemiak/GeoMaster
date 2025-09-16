using System;

namespace GeoMaster.Application.Interfaces
{
    public interface ICalculadoraService
    {
        double CalcularArea2D(object forma2D);
        double CalcularPerimetro2D(object forma2D);
        double CalcularVolume3D(object forma3D);
        double CalcularAreaSuperficial3D(object forma3D);
    }
}
