using InMemoryCachingWithDecorator.Services;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCachingWithDecorator.Controllers;

[Route("api/[controller]")]
public class VehicleController : Controller
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var vehicles = await _vehicleService.GetAllAsync().ConfigureAwait(false);
        return Ok(vehicles);
    }
}
