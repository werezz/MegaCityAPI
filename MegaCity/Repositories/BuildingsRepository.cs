using MegaCity.DbContexts;
using MegaCity.DbContexts.Entities;
using MegaCity.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaCity.Repositories;

public class BuildingsRepository : IBuildingsRepository, IDisposable
{
    private readonly BuildingsDbContext _context;

    public BuildingsRepository(BuildingsDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<IEnumerable<BuildingDbo>> FindAll()
    {
        return await _context.Buildings.ToListAsync();
    }

    public async Task<BuildingDbo> Update(string buildingId, Building building)
    {
        var results = await _context.Buildings.ToListAsync();
        var result = results.SingleOrDefault(b => b.Id.ToString() == buildingId);

        if (result != null)
        {
            result.Index = building.Index;
            result.Address = building.Address;
            result.EnergyUnits = building.EnergyUnits;
            result.Name = building.Name;
            _context.SaveChanges();
        }

        return result;
    }

    public async Task<BuildingDbo> Add(BuildingDbo building)
    {
        await _context.Buildings.AddAsync(building);
        _context.SaveChanges();

        return building;
    }
}