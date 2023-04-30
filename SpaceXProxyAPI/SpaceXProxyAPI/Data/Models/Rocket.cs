// <copyright file="Rocket.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Data.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Rocket model class.
    /// </summary>
    public class Rocket
    {
        /// <summary>
        /// Gets or sets rocket id.
        /// </summary>
        [JsonPropertyName("rocket_id")]
        public string RocketId { get; set; } = null!;

        /// <summary>
        /// Gets or sets rocket name.
        /// </summary>
        [JsonPropertyName("rocket_name")]
        public string RocketName { get; set; } = null!;
    }
}
