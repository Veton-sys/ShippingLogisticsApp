namespace API.DTOs
{
    public class PackageDto
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public decimal CalculateDimension()
        {
            return Width * Height * Depth;
        }
    }
}