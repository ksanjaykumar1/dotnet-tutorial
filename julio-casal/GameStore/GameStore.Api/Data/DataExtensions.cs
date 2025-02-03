using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

/*This code defines an extension method (MigrateDb) to apply 
database migrations automatically when the application starts.*/
public static class DataExtensions
{
    public static void MigrateDb( this WebApplication app)
    {
        /* Creates a service scope to resolve dependencies 
        from the dependency injection (DI) container.*/
        using var scope = app.Services.CreateScope();
        /*Retrieves an instance of GameStoreContext from the DI container.*/
        var dbContext =  scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }
}
