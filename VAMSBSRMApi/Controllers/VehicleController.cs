using Microsoft.AspNetCore.Mvc;
using VAMSBSRMApi.Application.Dtos;
using VAMSBSRMApi.Persistance.Services;

namespace VAMSBSRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;
        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;   
        }

        [HttpPost("RegisterVehicle")]
        public async Task<IActionResult> RegisterVehicle([FromBody] VehicleRegistrationDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _vehicleService.RegisterVehicleAsync(vehicleDto);

            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var category = await _vehicleService.GetVehicleByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}
