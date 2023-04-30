// <copyright file="LaunchMetadata.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Data.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Launch Metadata model class.
    /// </summary>
    public class LaunchMetadata
    {
        /// <summary>
        /// Gets or sets Flight number.
        /// </summary>
        [JsonPropertyName("flight_number")]
        public long FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets Mission Name.
        /// </summary>
        [JsonPropertyName("mission_name")]
        public string MissionName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether upcoming is true or false; shows if it is a past or upcoming launch.
        /// </summary>
        [JsonPropertyName("upcoming")]
        public bool Upcoming { get; set; }

        /// <summary>
        /// Gets or sets Launch year.
        /// </summary>
        [JsonPropertyName("launch_year")]
        public string LaunchYear { get; set; } = null!;

        /// <summary>
        /// Gets or sets launch site data.
        /// </summary>
        [JsonPropertyName("launch_site")]
        public LaunchSite LaunchSite { get; set; } = null!;
    }
}
