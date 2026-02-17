using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Services;

namespace NS_VehicleInventory.WebAPI.Controllers
{

    [ApiController]
    [Route("Vehicle")]
    public class NS_VehicleController : ControllerBase
    {

        private readonly NS_VehicleService _vehicleService;

        public NS_VehicleController(NS_VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync(ct);
            return Ok(vehicles);
        }


        [HttpGet("/getById/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var v = await _vehicleService.GetVehicleByIdAsync(id, ct);
            return Ok(v);
        }

        [HttpPost("/add")]
        public async Task<IActionResult> Add(NS_CreateVehicleRequest request, CancellationToken ct)
        {
            var newVehicle = await _vehicleService.CreateVehicleAsync(request, ct);
            return Ok(newVehicle);

        }

        [HttpPut("/updateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, NS_UpdateStatusRequest request, CancellationToken ct)
        {
            var result = await _vehicleService.UpdateVehicleStatusAsync(id, request.status, ct);
            return Ok(result);
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id, ct);
            return Ok(result);
        }
    }
}

