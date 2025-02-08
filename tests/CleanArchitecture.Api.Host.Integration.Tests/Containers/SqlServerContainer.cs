using Testcontainers.MsSql;

namespace CleanArchitecture.Api.Host.Integration.Tests.Containers;

public class SqlServerContainer
{
    
    public const string FixtureName = "SqlServerContainerFixture";

    public MsSqlContainer Container { get; } = new MsSqlBuilder()
        .WithImage(
            "mcr.microsoft.com/mssql/server:2022-latest"
        )
        .Build();
}