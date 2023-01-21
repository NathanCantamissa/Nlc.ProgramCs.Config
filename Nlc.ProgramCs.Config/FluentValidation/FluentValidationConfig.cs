using FluentValidation;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace Nlc.ProgramCs.Config.FluentValidation
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
