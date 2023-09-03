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
            //validation if package has values if not reutnr bad request and message in serviceRes
            var result = _courierService.GetCourierPrices(packageDto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> MakeOrder(OrderDto orderDto)
        {
            //validation
            // maybe global exception handler
            //maybe unit test per dicka shif
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