using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests;

[CollectionDefinition(nameof(WebApplicationFixture))]
public class WebApplicationCollection : ICollectionFixture<WebApplicationFixture>
{
    
}