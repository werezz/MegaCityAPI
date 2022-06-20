using MegaCity.Models;
using MegaCity.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaCity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingsController : ControllerBase
{
    private readonly IBuildingsService _service;

    public BuildingsController(IBuildingsService service)
    {
        _service = service;
    }

    [HttpGet("{buildingId}")]
    public async Task<ActionResult> GetBuilding(int buildingId)
    {
        return new OkObjectResult(await _service.FindBuildingById(buildingId));
    }

    [HttpGet()]
    public async Task<ActionResult> GetAllBuildings()
    {
        return new OkObjectResult(await _service.FindAll());
    }

    [HttpPost()]
    public async Task<ActionResult> AddBuilding([FromBody] Building building)
    {
        return new OkObjectResult(await _service.AddNewbuilding(building));
    }

    [HttpPut("{buildingId}")]
    public async Task<ActionResult> UpdateBuilding(string buildingId, [FromBody] Building building)
    {
        return new OkObjectResult(await _service.UpdateBuildingById(buildingId, building));
    }
}