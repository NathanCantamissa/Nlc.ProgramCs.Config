using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Nlc.ProgramCs.Config.Jwt
{
    public static class JwtConfig
    {
        /// <summary>
        /// Easy way to configure Jwt on your application. Just create a json object inside your appsettings like dedscribed bellow.
        /// "Jwt": {
        /// "Key": "your_issuer_signing_key",
        /// "Issuer": "your_isuer",
        /// "Audience": "your_audience"
        /// }
        /// </summary>
        /// <param name="services">Just to set the extension method</param>
        /// <param name="configuration">Just pass builder.Configuration, to get the info from appsettings</param>
        public static void AddJwtConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
        }
    }
}