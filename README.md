# clean-architecture
Sample repository to demonstrate Clean Architecture in Asp.Net Core

## Start 

To start the project and instance of Sql Server is mandatory. You can install Sql Server or run a Sql docker container instance.

Remember to update the connection string in the appSettings.Development.json file. Once the connection string is updated run the ef migrations to create the database schema.

```
dotnet ef migrations add InitialMigration -c SystemDbContext -p .\src\CleanArchitecture.Infrastructure.SqlServer\ -s .\src\CleanArchitecture.Api.Host\ -o Migrations\System
dotnet ef database update -c SystemDbContext -p .\src\CleanArchitecture.Infrastructure.SqlServer\ -s .\src\CleanArchitecture.Api.Host\
```

## Technologies

This project is based on Microsoft technologies, the following list are the start technologies to build the project. Once the project grows some new technologies will be added to the project.

- [Asp.Net Core API](https://dotnet.microsoft.com/es-es/apps/aspnet)
- [MediatR](https://github.com/jbogard/MediatR)
- [EntityFramework Core](https://learn.microsoft.com/es-es/ef/core/)

## Unit and integration tests

The project start with unit and integration tests. The technologies used for the tests are the following:

- [xUnit](https://xunit.net/)
- [FluentAssertions v.7x (be careful because from the version 8 FluentAssertions a paid license is mandatory)](https://fluentassertions.com/)
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/microsoft.net.test.sdk)
- [TestContainers](https://testcontainers.com/)
- [coverlet.collector](https://www.nuget.org/packages/coverlet.collector)