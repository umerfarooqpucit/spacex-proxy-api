// <copyright file="LaunchesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SpaceXProxyAPI.Clients;
    using SpaceXProxyAPI.Data.Models;

    /// <summary>
    /// Implements launch api endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LaunchesController : ControllerBase
    {
        private readonly LaunchClient launchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesController"/> class.
        /// </summary>
        /// <param name="launchService">Launch Service.</param>
        public LaunchesController(LaunchClient launchService)
        {
            this.launchService = launchService;
        }

        /// <summary>
        /// Gets all past and upcoming launches.
        /// </summary>
        /// <response code="200">OK.</response>
        /// <returns>A  representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LaunchMetadata>))]
        public async Task<IActionResult> GetAll()
        {
            return await this.launchService.GetAllLaunches();
        }

        /// <summary>
        /// Get Launch by id.
        /// </summary>
        /// <param name="id">the Id of the Launch.</param>
        /// <response code="200">OK.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>LaunchMetadata.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LaunchDetail))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLaunchById(int id)
        {
            return await this.launchService.GetLaunchById(id);
        }
    }
}
