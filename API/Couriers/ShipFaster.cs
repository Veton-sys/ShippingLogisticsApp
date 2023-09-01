using API.DTOs;
using API.Entities;

namespace API.Couriers
{
    public class ShipFaster : Courier
    {
        public ShipFaster(string name) : base(name)
        {
        }

        public override double CalculateDimensionPrice(PackageDto packageDto)
        {
            return packageDto.CalculateDimension() <= 1000 ? 11.99 : 21.99;
        }
        public override double CalculateWeightPrice(PackageDto packageDto)
        {
            return packageDto.Weight <= 15 ? 16.50 : packageDto.Weight <= 25 ? 36.50 : 40 + (packageDto.Weight - 25)*0.417;
        }
        public override bool ValidateDimension(PackageDto packageDto)
        {
            return packageDto.CalculateDimension() <= 1700;
        }
        public override bool ValidateWeight(PackageDto packageDto)
        {
            return packageDto.Weight > 10 && packageDto.Weight <= 30;
        }
    }
}