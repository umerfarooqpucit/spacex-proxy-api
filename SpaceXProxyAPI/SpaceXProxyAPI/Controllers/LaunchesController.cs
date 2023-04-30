// <copyright file="LaunchesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SpaceXProxyAPI.Data.Models;

    /// <summary>
    /// Implements launch api endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LaunchesController : ControllerBase
    {
        /// <summary>
        /// Gets all past and upcoming launches.
        /// </summary>
        /// <returns>A  representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<List<LaunchMetadata>> GetAll()
        {
            return new List<LaunchMetadata>();
        }
    }
}
