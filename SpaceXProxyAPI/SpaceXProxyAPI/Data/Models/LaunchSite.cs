// <copyright file="LaunchSite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Data.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Launch Site model class.
    /// </summary>
    public class LaunchSite
    {
        /// <summary>
        /// Gets or sets SiteId.
        /// </summary>
        [JsonPropertyName("site_id")]
        public string SiteId { get; set; } = null!;

        /// <summary>
        /// Gets or sets Site name.
        /// </summary>
        [JsonPropertyName("site_name")]
        public string SiteName { get; set; } = null!;

        /// <summary>
        /// Gets or sets Site Full Name.
        /// </summary>
        [JsonPropertyName("site_name_long")]
        public string SiteNameLong { get; set; } = null!;
    }
}
