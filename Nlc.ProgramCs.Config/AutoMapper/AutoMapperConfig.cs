using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Nlc.ProgramCs.Config.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
