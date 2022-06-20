using MegaCity.DbContexts.Entities;
using MegaCity.Models;
using MegaCity.Repositories;

namespace MegaCity.Services;

public class BuildingsService : IBuildingsService
{
    private readonly IBuildingsRepository _repository;

    public BuildingsService(IBuildingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Building>> FindAll()
    {
        return (await _repository.FindAll()).Select(Map);
    }

    public async Task<Building?> FindBuildingById(int id)
    {
        return (await _repository.FindAll()).Select(Map).FirstOrDefault(x => x.Id == id);
    }

    public async Task<Building?> AddNewbuilding(Building building)
    {
        BuildingDbo test = MapDbo(building);

        return Map(await _repository.Add(test));
    }

    public async Task<Building?> UpdateBuildingById(string buildingId, Building building)
    {
        return Map(await _repository.Update(buildingId, building));
    }

    private Building Map(BuildingDbo building)
    {
        return new Building
        {
            Address = building.Address,
            EnergyUnitMax = building.EnergyUnitMax,
            EnergyUnits = building.EnergyUnits,
            Id = building.Id,
            Index = building.Index,
            Name = building.Name,
            SectorCode = building.SectorCode
        };
    }

    private BuildingDbo MapDbo(Building building)
    {
        return new BuildingDbo
        {
            Address = building.Address,
            EnergyUnitMax = building.EnergyUnitMax,
            EnergyUnits = building.EnergyUnits,
            Index = building.Index,
            Name = building.Name,
            SectorCode = building.SectorCode
        };
    }
}