using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceXProxyAPI.Clients;
using SpaceXProxyAPI.Controllers;
using SpaceXProxyAPI.Data.Models;
using System.Dynamic;

namespace SpaceXProxyAPI.Test
{
    [TestClass]
    public class LaunchProxyAPITest
    {
        private readonly LaunchesController launchesController;

        public LaunchProxyAPITest()
        {
            // Bootstarping dependencies and creating controller object.
            var dependencyBootstrap = new DepedencyInjectionBootstrap();
            var serviceProvider = dependencyBootstrap.GetServiceProvider();
            var launchClient = serviceProvider.GetService(typeof(LaunchClient)) as LaunchClient;
            launchesController = new LaunchesController(launchClient!);
        }

        /// <summary>
        /// Method to test GetAll Endpoint.
        /// </summary>
        [TestMethod]
        public async Task GetAll_ShouldReturnAllLaunches()
        {
            var result = await launchesController.GetAll() as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(List<LaunchMetadata>));
        }

        /// <summary>
        /// Method to test Get Launch By Id Endpoint.
        /// <paramref name="flightNumber"/>
        /// </summary>
        [DataTestMethod]
        [DataRow(10)]
        [DataRow(20)]
        [DataRow(2)]
        [DataRow(42)]
        [DataRow(29)]
        [DataRow(99)]
        [DataRow(102)]
        public async Task GetLaunchById_ShouldReturnLaunchWithSpecificId(int flightNumber)
        {
            var result = await launchesController.GetLaunchById(flightNumber) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(LaunchDetail));
            Assert.AreEqual((result.Value as LaunchDetail)!.FlightNumber, flightNumber);
        }

        /// <summary>
        /// Method to test Get Launch By Id Endpoint with Ids out of range. As max flight number is 110.
        /// <paramref name="flightNumber"/>
        /// </summary>
        [DataTestMethod]
        [DataRow(120)]
        [DataRow(220)]
        [DataRow(142)]
        [DataRow(229)]
        [DataRow(199)]
        [DataRow(182)]
        public async Task GetLaunchById_ShouldReturnNotFound(int flightNumber)
        {
            var result = await launchesController.GetLaunchById(flightNumber) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        /// <summary>
        /// Method to test Get Launch By Id Endpoint with Ids out of range by finding max.
        /// </summary>
        [TestMethod]
        public async Task GetLaunchById_ShouldReturnNot_Found()
        {
            var allLaunches = (await launchesController.GetAll() as ObjectResult)!.Value as List<LaunchMetadata>;
            var result = await launchesController.GetLaunchById((int) allLaunches!.Max(l => l.FlightNumber) + 1) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}