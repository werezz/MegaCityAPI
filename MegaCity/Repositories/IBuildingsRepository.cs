using MegaCity.DbContexts.Entities;
using MegaCity.Models;

namespace MegaCity.Repositories;

public interface IBuildingsRepository
{
    Task<IEnumerable<BuildingDbo>> FindAll();
    Task<BuildingDbo> Update(string buildingId, Building building);
    Task<BuildingDbo> Add(BuildingDbo building);
}