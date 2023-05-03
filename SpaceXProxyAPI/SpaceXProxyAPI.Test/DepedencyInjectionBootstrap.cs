using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceXProxyAPI.Clients;
using SpaceXProxyAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXProxyAPI.Test
{
    /// <summary>
    /// Class to inject dependencies.
    /// </summary>
    internal class DepedencyInjectionBootstrap
    {
        private readonly ServiceProvider serviceProvider;

        public DepedencyInjectionBootstrap()
        {
            // Loading the test config file.
            ConfigurationBuilder builder = new ConfigurationBuilder();
            var jsonPath = $"{Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName}/testsettings.json";
            var config = builder.AddJsonFile(jsonPath).Build();

            var services = new ServiceCollection();

            // Getting the baseUrl Required for RestClient.
            var baseUrl = config.GetSection("TestSettings").GetValue<string>("spacexInternalApiBaseUrl");

            services.AddSingleton(_ => new RestClient(baseUrl));
            services.AddScoped<LaunchClient>();

            this.serviceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}
