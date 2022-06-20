using MegaCity.Controllers;
using MegaCity.Models;
using MegaCity.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MegaCity.Tests
{
    public class Tests
    {
        private Mock<IBuildingsService> _buildingsService;

        private BuildingsController _sut;

        private List<Building> buildings = new List<Building>()
            {
                new Building { Id = 1, Name = "Big Building", Address = "Highway 420", Index = "NO600", EnergyUnits = 400, EnergyUnitMax = 500, SectorCode = "CX60" },
                new Building { Id = 2, Name = "Small Building", Address = "Highway 1200", Index = "NO90000", EnergyUnits = 20, EnergyUnitMax = 100, SectorCode = "CX12" }
            };

        [SetUp]
        public void Intialize()
        {
            _buildingsService = new Mock<IBuildingsService>();

            _sut = new BuildingsController(_buildingsService.Object);
        }

        [Test]
        public async Task GetAllBuildings_Returns_Status_Ok_When_Found_Buildings()
        {
            // arrange
            _buildingsService
               .Setup(x => x.FindAll())
               .ReturnsAsync(buildings);

            // act
            var result = await _sut.GetAllBuildings();

            // assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task AddBuilding_Returns_Status_Ok_When_Added_New_Building()
        {
            // arrange
            _buildingsService
               .Setup(x => x.AddNewbuilding(It.IsAny<Building>()))
               .ReturnsAsync(buildings[0]);

            // act
            var result = await _sut.AddBuilding(buildings[0]);

            // assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task UpdateBuilding_Returns_Status_Ok_When_Building_Updated()
        {
            // arrange
            _buildingsService
               .Setup(x => x.UpdateBuildingById(It.IsAny<string>(), It.IsAny<Building>()))
               .ReturnsAsync(buildings[0]);

            // act
            var result = await _sut.UpdateBuilding("1", buildings[0]);

            // assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task GetBuilding_Returns_Status_Ok_When_Found_Building_By_Id()
        {
            // arrange
            _buildingsService
               .Setup(x => x.FindBuildingById(It.IsAny<int>()))
               .ReturnsAsync(buildings[0]);

            // act
            var result = await _sut.GetBuilding(1);

            // assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }
    }
}