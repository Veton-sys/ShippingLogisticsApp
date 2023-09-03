using API.Couriers;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        public List<Courier> _couriers;
        ICourierService _courierService;
        public ShippingController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<Courier>>> CalculateCourierPrices([FromQuery]PackageDto packageDto)
        {
            if (_courierService.CheckPackageInformation(packageDto))
            {
                return BadRequest("Package information not set correctly");
            }
            var result = _courierService.GetCourierPrices(packageDto);
            if (!result.Success)
            {
                result.Message = "Couriers couldn't be retrieved";
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> MakeOrder(OrderDto orderDto)
        {
            if (_courierService.CheckPackageInformation(orderDto.PackageDto))
            {
                return BadRequest("Package information not set correctly");
            }
            var result = await _courierService.MakeOrder(orderDto);
            if(!result.Success)
            {
                result.Message = "Order couldn't be placed";
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}