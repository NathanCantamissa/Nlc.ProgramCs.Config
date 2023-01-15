using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Nlc.ProgramCs.Config.Swagger
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Easy way to config the swagger options, with bearer authentication.
        /// </summary>
        /// <param name="services">Just to set the extension method</param>
        /// <param name="name">SwaggerDoc name parameter</param>
        /// <param name="openApiInfo">OpenApiInfo class, to set the parameters as you desire</param>
        public static void AddSwaggerBearerConfig(this IServiceCollection services, string name, OpenApiInfo openApiInfo)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(name, openApiInfo);
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new string[]{}
                    }
                });
            });
        }
    }
}