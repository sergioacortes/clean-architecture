using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests;

[CollectionDefinition(nameof(BaseFixtureCollection))]
public class BaseFixtureCollection : ICollectionFixture<BaseFixtureCollection>
{
}