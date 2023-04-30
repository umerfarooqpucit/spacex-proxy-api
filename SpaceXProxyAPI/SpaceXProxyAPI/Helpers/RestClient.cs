// <copyright file="RestClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Helpers
{
    /// <summary>
    /// Rest Client class; An abstraction over HttpClient Methods. Currently it has only Get method for simplicity.
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// Http client object.
        /// </summary>
        private readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Internal API Base URL.</param>
        public RestClient(string baseUrl)
        {
            this.httpClient.BaseAddress = new Uri(baseUrl);
        }

        /// <summary>
        /// Http Get Request.
        /// </summary>
        /// <param name="url">Url to request to.</param>
        /// <param name="parameters">Query Params.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> Get(string url, Dictionary<string, string> parameters)
        {
            return await this.httpClient.GetAsync(parameters == null ? url : $"{url}?{string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
        }
    }
}
