﻿using Microsoft.Extensions.DependencyInjection;
using wca.compras.domain.Interfaces.Services;
using wca.compras.services;

namespace wca.compras.crosscutting.DependencyInjection
{
    public static class ConfigureServices
    {
        public static void ConfigureDependencyService(this IServiceCollection services)
        {
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IPermissionService, PermissionService>();
        }
    }
}
