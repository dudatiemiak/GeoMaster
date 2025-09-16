namespace GeoMaster.GeoMaster.Infrastructure
{
    public class CalculationLogger
    {
        private readonly ILogger<CalculationLogger> _logger;

        public CalculationLogger(ILogger<CalculationLogger> logger)
        {
            _logger = logger;
        }

        public void Log2DCalculation(string shape, double area, double perimeter)
        {
            _logger.LogInformation($"2D Calculation: Shape = {shape}, Area = {area}, Perimeter = {perimeter}");
        }

        public void Log3DCalculation(string shape, double volume, double surfaceArea)
        {
            _logger.LogInformation($"3D Calculation: Shape = {shape}, Volume = {volume}, Surface Area = {surfaceArea}");
        }
    }
}
