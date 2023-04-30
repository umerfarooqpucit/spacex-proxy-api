// <copyright file="RestClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Helpers
{
    using System.Text.Json;
    using System.Text.Json.Serialization;

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
        /// Http Get Method.
        /// </summary>
        /// <typeparam name="T">Generic Response Type.</typeparam>
        /// <param name="url">Url to request to.</param>
        /// <param name="parameters">Query params.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<T> Get<T>(string url, Dictionary<string, string>? parameters = null)
        {
            try
            {
                return await this.httpClient
                    .GetFromJsonAsync<T>(parameters == null ? url : $"{url}?{string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
            }
            catch (HttpRequestException)
            {
                // Non Success response.
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException)
            {
                // Invalid Content type.
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException)
            {
                // Invalid JSON.
                Console.WriteLine("Invalid JSON.");
            }

            return default(T);
        }
    }
}
