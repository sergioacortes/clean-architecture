using Xunit;

namespace CleanArchitecture.BackOffice.Api.Host.Integration.Tests;

[CollectionDefinition(nameof(WebApplicationCollection))]
public class WebApplicationCollection : ICollectionFixture<WebApplicationFixture>
{
}