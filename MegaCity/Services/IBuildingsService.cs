using MegaCity.Models;

namespace MegaCity.Services;

public interface IBuildingsService
{
    public Task<IEnumerable<Building>> FindAll();

    public Task<Building?> FindBuildingById(int id);
    public Task<Building?> UpdateBuildingById(string buildingId, Building building);
    public Task<Building?> AddNewbuilding(Building building);
}