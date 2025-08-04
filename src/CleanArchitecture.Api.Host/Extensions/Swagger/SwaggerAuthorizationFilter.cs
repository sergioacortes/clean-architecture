using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitecture.Api.Host.Extensions.Swagger;

public sealed class SwaggerAuthorizationFilter : IOperationFilter
{
    private readonly IEnumerable<OpenApiSecurityRequirement> _securityRequirements;
    private readonly OpenApiResponses _authorizedResponses;

    public SwaggerAuthorizationFilter()
    {
        _securityRequirements = new List<OpenApiSecurityRequirement>
        {
            new()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "CleanArchitecture",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    Array.Empty<string>()
                }
            },
            new()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "apiKey",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    Array.Empty<string>()
                }
            }
        };

        _authorizedResponses = new OpenApiResponses()
        {
            ["401"] = new OpenApiResponse { Description = "User not authenticated." },
            ["403"] = new OpenApiResponse { Description = "User not authorized to perform this action." },
        };
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var securityRequirement in _securityRequirements)
        {
            operation.Security.Add(securityRequirement);
        }

        foreach (var response in _authorizedResponses)
        {
            operation.Responses.TryAdd(response.Key, response.Value);
        }
    }
}
