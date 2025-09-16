using GeoMaster.Application.Interfaces;
using System;

namespace GeoMaster.Domain.Entities
{
    public class Circulo : ICalculos2D
    {
        public double Raio { get; set; }

        public Circulo(double raio)
        {
            Raio = raio;
        }

        public double CalcularArea()
        {
            return Math.PI * Raio * Raio;
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }
    }
}
