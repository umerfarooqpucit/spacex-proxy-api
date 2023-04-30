// <copyright file="LaunchDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Data.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Launch Detail model class.
    /// </summary>
    public class LaunchDetail : LaunchMetadata
    {
        /// <summary>
        /// Gets or sets Mission Id.
        /// </summary>
        [JsonPropertyName("mission_id")]
        public string[] MissionId { get; set; } = new string[0];

        /// <summary>
        /// Gets or sets launch date UTC.
        /// </summary>
        [JsonPropertyName("launch_date_utc")]
        public DateTimeOffset LaunchDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is tentative or not.
        /// </summary>
        [JsonPropertyName("is_tentative")]
        public bool IsTentative { get; set; }

        /// <summary>
        /// Gets or sets launch window.
        /// </summary>
        [JsonPropertyName("launch_window")]
        public long? LaunchWindow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether launch was successful or not.
        /// </summary>
        [JsonPropertyName("launch_success")]
        public bool? LaunchSuccess { get; set; }

        /// <summary>
        /// Gets or sets rocket data.
        /// </summary>
        [JsonPropertyName("rocket")]
        public Rocket Rocket { get; set; } = new Rocket();

        /// <summary>
        /// Gets or sets Details.
        /// </summary>
        [JsonPropertyName("details")]
        public string? Details { get; set; }
    }
}
