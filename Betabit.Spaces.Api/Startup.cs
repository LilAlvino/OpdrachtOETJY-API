using Betabit.Spaces.Repositories;
using Betabit.Spaces.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;

[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(Betabit.Spaces.Api.Startup))]

namespace Betabit.Spaces.Api
{
    //Excluded because of our choice to not cover startup files
    [ExcludeFromCodeCoverage]
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();

            var config = (IConfiguration)builder
                .Services
                .First(s => s.ServiceType == typeof(IConfiguration))
                .ImplementationInstance;
            builder.Services.Configure<SpacesOptions>(config);
            builder.Services.Configure<DataOptions>(config);
            builder.Services.AddSingleton<ISpacesRepository, SpacesRepository>();
            builder.Services.AddSingleton<IReservationsRepository, ReservationsRepository>();
            builder.Services.AddSingleton<IReservationsService, ReservationsService>();
        }
    }
}