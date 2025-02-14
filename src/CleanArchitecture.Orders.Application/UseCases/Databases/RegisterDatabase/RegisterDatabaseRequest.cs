using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Databases.RegisterDatabase;

public record RegisterDatabaseRequest(string ServerName, string DatabaseName, string UserName, string Password) : IRequest<RegisterDatabaseResponse>;