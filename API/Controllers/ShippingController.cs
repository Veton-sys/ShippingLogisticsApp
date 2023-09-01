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

        [HttpPost]
        public ActionResult<List<Courier>> CalculateCourierPrices(PackageDto packageDto)
        {
            return Ok(_courierService.GetCourierPrices(packageDto));
        }

        [HttpPost]
        public void MakeOrder(OrderDto orderDto)
        {
            _courierService.MakeOrder(orderDto);
        }
    }
}