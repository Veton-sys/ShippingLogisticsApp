using API.DTOs;
using API.Entities;

namespace API.Couriers
{
    public class Cargo4You : Courier
    {
        public Cargo4You(string name) : base(name)
        {
        }

        public override bool ValidateDimension(PackageDto packageDto)
        {
            return packageDto.CalculateDimension() <= 2000; 
        }
        public override bool ValidateWeight(PackageDto packageDto)
        {
            return packageDto.Weight <= 20;
        }
        public override double CalculateDimensionPrice(PackageDto packageDto)
        {
            return packageDto.CalculateDimension() <= 1000 ? 10 : 20;
        }
        public override double CalculateWeightPrice(PackageDto packageDto)
        {
            return packageDto.Weight <= 2 ? 15 : packageDto.Weight <= 15 ? 18 : 35;
        }
    }
}