using Microsoft.OpenApi.Models;

namespace Web.Customer.Bff.Extension;

public static class SwaggerExtension
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.UseOneOfForPolymorphism();
            options.SwaggerDoc
            (
                "v1"
                , new OpenApiInfo
                {
                    Title = "ETicketStore.Api.Admin",
                    Version = "v1"
                }
            );
            options.AddSecurityDefinition
            (
                "Bearer"
                , new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. Check your TOKEN",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                }
            );
            options.AddSecurityRequirement
            (
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme, Id = "Bearer"
                            },
                            Scheme = "oauth2", Name = "Bearer", In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                }
            );
        });
    }
}