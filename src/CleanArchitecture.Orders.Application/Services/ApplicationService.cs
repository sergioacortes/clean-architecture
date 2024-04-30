using CleanArchitecture.Orders.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Orders.Application.Services;

public class ApplicationService (IOptions<ConfigurationOptions> options)
{

    public int GetSeconds() => options.Value.Seconds;

}