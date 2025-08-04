using System.Reflection;
using CleanArchitecture.Api.Host.Extensions.Swagger;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CleanArchitecture.Api.Host.Extensions;

public static class SwaggerExtensions
{
    
    internal static IServiceCollection AddSwaggerOpenApi(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetEntryAssembly()!.GetName().Name, Version = "v1" });
            options.AddAuthentication();
            options.AddSwaggerDocumentation();
        });

        return services;
    }

    public static WebApplication UseSwaggerOpenApi(this WebApplication application)
    {
        var path = string.IsNullOrEmpty(application.Configuration.GetValue<string>("Swagger:Url"))
            ? string.Empty
            : $"/{application.Configuration.GetValue<string>("Swagger:Url")}";

        application.UseSwagger(c =>
        {
            c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
            {
                new() { Url = $"https://{httpReq.Host.Value}{path}" }
            });
        });
        application.UseSwaggerUI(options =>
        {
            options.DocExpansion(DocExpansion.None);
            options.SwaggerEndpoint($"{path}/swagger/v1/swagger.json", "Api Documents Editor");
        });

        return application;
    }
    
    private static void AddAuthentication(this SwaggerGenOptions options)
    {
        options.OperationFilter<SwaggerAuthorizationFilter>();
        options.AddSecurityDefinition("CleanArchitecture",
                                      new OpenApiSecurityScheme
                                      {
                                          Name = "Authorization",
                                          In = ParameterLocation.Header,
                                          Type = SecuritySchemeType.Http,
                                          Description = "JWT authorization",
                                          BearerFormat = "JWT",
                                          Scheme = "Bearer"
                                      });
    }

    private static void AddSwaggerDocumentation(this SwaggerGenOptions options)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
    
}