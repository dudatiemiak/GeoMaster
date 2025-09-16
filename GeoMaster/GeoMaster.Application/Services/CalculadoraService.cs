using GeoMaster.Application.Interfaces;
using System;

namespace GeoMaster.Application.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double CalcularArea2D(object forma2D)
        {
            if (forma2D is ICalculos2D calculos2D)
                return calculos2D.CalcularArea();
            throw new ArgumentException("Objeto não implementa ICalculos2D");
        }

        public double CalcularPerimetro2D(object forma2D)
        {
            if (forma2D is ICalculos2D calculos2D)
                return calculos2D.CalcularPerimetro();
            throw new ArgumentException("Objeto não implementa ICalculos2D");
        }

        public double CalcularVolume3D(object forma3D)
        {
            if (forma3D is ICalculos3D calculos3D)
                return calculos3D.CalcularVolume();
            throw new ArgumentException("Objeto não implementa ICalculos3D");
        }

        public double CalcularAreaSuperficial3D(object forma3D)
        {
            if (forma3D is ICalculos3D calculos3D)
                return calculos3D.CalcularAreaSuperficial();
            throw new ArgumentException("Objeto não implementa ICalculos3D");
        }
    }
}
