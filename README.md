# Clean architecture - Domain driven design

This is a clean architecture with domain driven design pattern solution. Within this repository you can find the following projects which correspond to the initial sample.

Projects
- Api
- Application
- Domain
- Infrastructure


## Migrations

Execute the following commands to apply the database migrations before start the project.

```
dotnet ef migrations add InitialMigration -c SystemDbContext -p .\src\CleanArchitecture.Infrastructure\ -s .\src\CleanArchitecture.Api.Host\ -o Migrations\System
dotnet ef database update -c SystemDbContext -p .\src\CleanArchitecture.Infrastructure\ -s .\src\CleanArchitecture.Api.Host\
```