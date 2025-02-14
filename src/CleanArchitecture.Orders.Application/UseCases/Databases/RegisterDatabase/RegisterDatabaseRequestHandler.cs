using CleanArchitecture.Orders.Domain.Databases.Entities;
using CleanArchitecture.Orders.Domain.Databases.Repositories;
using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Databases.RegisterDatabase;

public class RegisterDatabaseRequestHandler(IDatabasesDomainRepository databasesDomainRepository) : IRequestHandler<RegisterDatabaseRequest, RegisterDatabaseResponse>
{
    public async Task<RegisterDatabaseResponse> Handle(RegisterDatabaseRequest request, CancellationToken cancellationToken)
    {
        var database = Database.Create(request.ServerName, request.DatabaseName, request.UserName, request.Password);
        
        await databasesDomainRepository.AddAsync(database, cancellationToken);
        await databasesDomainRepository.SaveChangesAsync(cancellationToken);
        
        var response = new RegisterDatabaseResponse(database.Id, database.ServerName, database.DatabaseName, database.UserName, database.Password);

        return response;
    }
}