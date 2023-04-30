// <copyright file="LaunchesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SpaceXProxyAPI.Data.Models;
    using SpaceXProxyAPI.Services;

    /// <summary>
    /// Implements launch api endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LaunchesController : ControllerBase
    {
        private readonly LaunchService launchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesController"/> class.
        /// </summary>
        /// <param name="launchService">Launch Service.</param>
        public LaunchesController(LaunchService launchService)
        {
            this.launchService = launchService;
        }

        /// <summary>
        /// Gets all past and upcoming launches.
        /// </summary>
        /// <returns>A  representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LaunchMetadata>))]
        public async Task<List<LaunchMetadata>> GetAll()
        {
            return await this.launchService.GetAllLaunches();
        }

        /// <summary>
        /// Get Launch by id.
        /// </summary>
        /// <param name="id">the Id of the Launch.</param>
        /// <returns>LaunchMetadata.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LaunchMetadata))]
        public async Task<LaunchMetadata> GetLaunchById(int id)
        {
            return await this.launchService.GetLaunchById(id);
        }
    }
}
