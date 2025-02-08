using CleanArchitecture.Api.Host.Integration.Tests.Containers;
using Xunit;

namespace CleanArchitecture.Api.Host.Integration.Tests;

[CollectionDefinition(SqlServerContainer.FixtureName)]
public class SqlServerContainerCollection : ICollectionFixture<SqlServerContainer>
{
    
}