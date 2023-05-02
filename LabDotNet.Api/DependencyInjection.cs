using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabDotNet.DataBase.DataAccess;
using LabDotNet.DataBase.DataAccess.Interfaces;
using LabDotNet.Models.Translators;
using LabDotNet.Models.Translators.Interfaces;
using LabDotNet.Services.Interfaces;
using LabDotNet.Services.Services;

namespace LabDotNet.Api
{
    public static class DependencyInjection
    {
        public static void AddDependencyServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped<IQueries, Queries>();
            services.AddScoped<ICommands, Commands>();
            services.AddTransient<IToEntityTranslator, ToEntityTranslator>();
            services.AddTransient<IToDtoTranslator, ToDtoTranslator>();
        }
    }
}