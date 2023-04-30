// <copyright file="Endpoint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceXProxyAPI.Data.Constants
{
    /// <summary>
    /// Class for SpaceX API endpoints.
    /// </summary>
    public static class Endpoint
    {
        /// <summary>
        /// All Launches Endpoint.
        /// </summary>
        public const string AllLaunches = "/v3/launches";

        /// <summary>
        /// Past Launches Endpoint.
        /// </summary>
        public const string PastLaunches = "/v3/launches/past";

        /// <summary>
        /// Upcoming Launches Endpoint.
        /// </summary>
        public const string UpcomingLaunches = "/v3/launches/upcoming";
    }
}
