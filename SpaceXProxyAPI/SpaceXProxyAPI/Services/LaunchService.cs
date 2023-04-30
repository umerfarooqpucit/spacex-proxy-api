// <copyright file="LaunchService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Services
{
    using SpaceXProxyAPI.Data.Models;
    using SpaceXProxyAPI.Helpers;

    /// <summary>
    /// Contains methods to fetch lanches data.
    /// </summary>
    public class LaunchService
    {
        /// <summary>
        /// Rest Client object.
        /// </summary>
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchService"/> class.
        /// </summary>
        /// <param name="restClient">Rest Client object.</param>
        public LaunchService(RestClient restClient)
        {
            this.restClient = restClient;
        }

        /// <summary>
        /// Gets All past and upcoming launches.
        /// </summary>
        /// <returns>A List of Launch Metadata.</returns>
        public async Task<List<LaunchMetadata>> GetAllLaunches()
        {
            return await this.restClient.Get<List<LaunchMetadata>>(Data.Constants.Endpoint.AllLaunches);
        }

        /// <summary>
        /// Gets a specific launch by its id.
        /// </summary>
        /// <param name="id">the Id of the Launch.</param>
        /// <returns>launchMetadata.</returns>
        public async Task<LaunchDetail> GetLaunchById(int id)
        {
            return await this.restClient.Get<LaunchDetail>($"{Data.Constants.Endpoint.AllLaunches}/{id}");
        }
    }
}
