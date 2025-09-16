using GeoMaster.GeoMaster.Application.Interfaces;

namespace GeoMaster.GeoMaster.Application.Services
{
    public class Geometry2DService : I2DCalculator
    {
        public double CalcularArea(double width, double height)
        {
            return width * height;
        }

        public double CalcularPerimetro(double width, double height)
        {
            return 2 * (width + height);
        }
    }
}
