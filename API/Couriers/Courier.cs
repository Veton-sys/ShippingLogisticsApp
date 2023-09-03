using API.DTOs;

namespace API.Couriers
{
    public abstract class Courier
    {
        public Courier(string name)
        {
            Name = name;
            Price = 0;
        }
        public string Name { get; set; }

        public double Price { get; set; }

        public abstract bool ValidateDimension(PackageDto packageDto);
        public abstract bool ValidateWeight(PackageDto packageDto);
        public abstract double CalculateDimensionPrice(PackageDto packageDto);
        public abstract double CalculateWeightPrice(PackageDto packageDto);
        public void CalculatePrice(PackageDto packageDto)
        {
            var dimensionPrice = CalculateDimensionPrice(packageDto);
            var weightPrice = CalculateWeightPrice(packageDto);

            Price = Math.Max(dimensionPrice, weightPrice);
        }
    }
}