using API.DTOs;
using API.Entities;

namespace API.Couriers
{
    public class MaltaShip : Courier
    {
        public MaltaShip(string name) : base(name)
        {
        }

        public override double CalculateDimensionPrice(PackageDto packageDto)
        {
            var dimension = packageDto.CalculateDimension();
            return dimension <= 1000 ? 9.50 : dimension <= 2000 ? 19.50 : dimension <= 5000 ? 48.50 : 147.50;
        }

        public override double CalculateWeightPrice(PackageDto packageDto)
        {
            return packageDto.Weight <= 20 ? 16.99 : packageDto.Weight <= 30 ? 33.99 : 43.99 + (packageDto.Weight - 30)*0.41;
        }

        public override bool ValidateDimension(PackageDto packageDto)
        {
            return packageDto.CalculateDimension() >= 500;
        }

        public override bool ValidateWeight(PackageDto packageDto)
        {
            return packageDto.Weight >= 10;
        }
    }
}