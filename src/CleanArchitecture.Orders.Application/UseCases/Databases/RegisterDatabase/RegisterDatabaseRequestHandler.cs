using CleanArchitecture.Orders.Domain.Databases.Entities;
using CleanArchitecture.Orders.Domain.Databases.Repositories;
using CleanArchitecture.Orders.Infrastructure.SqlServer.Base;
using MediatR;

namespace CleanArchitecture.Orders.Application.UseCases.Databases.RegisterDatabase;

public class RegisterDatabaseRequestHandler(IDatabasesDomainRepository databasesDomainRepository) : IRequestHandler<RegisterDatabaseRequest, RegisterDatabaseResponse>
{
    public async Task<RegisterDatabaseResponse> Handle(RegisterDatabaseRequest request, CancellationToken cancellationToken)
    {

        await DisableCurrentDatabases(cancellationToken).ConfigureAwait(false);
        
        var database = Database.Create(request.ServerName, request.DatabaseName, request.UserName, request.Password);
        
        await databasesDomainRepository.AddAsync(database, cancellationToken).ConfigureAwait(false);;
        await databasesDomainRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);;
        
        var response = new RegisterDatabaseResponse(database.Id, database.ServerName, database.DatabaseName, database.UserName, database.Password);

        return response;
        
    }

    private async Task DisableCurrentDatabases(CancellationToken cancellationToken)
    {
        
        await ((DomainRepository<Database, Guid>)databasesDomainRepository)
            .ExecuteUpdateAsync(r => r.IsActive, 
                setter =>
                setter.SetProperty(p => p.IsActive, false
            ), cancellationToken).ConfigureAwait(false);
        
    }
}