namespace CleanArchitecture.Orders.Application.UseCases.Databases.RegisterDatabase;

public record RegisterDatabaseResponse(Guid Id, string ServerName, string DatabaseName, string UserName, string Password);