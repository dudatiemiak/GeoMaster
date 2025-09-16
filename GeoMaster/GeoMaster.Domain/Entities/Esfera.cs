using GeoMaster.Application.Interfaces;
using System;

namespace GeoMaster.Domain.Entities
{
    public class Esfera : ICalculos3D
    {
        public double Raio { get; set; }

        public Esfera(double raio)
        {
            Raio = raio;
        }

        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
        }

        public double CalcularAreaSuperficial()
        {
            return 4 * Math.PI * Raio * Raio;
        }
    }
}
