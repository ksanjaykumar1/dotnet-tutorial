using System;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

/* GameStoreDbContext class is a DbContext for an Entity Framework Core (EF Core)-based application.
It acts as a bridge between your C# application and the database. */

public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.onModelCreating(modelBuilder);
        modelBuilder.Entity<Genre>().HasData(
            new{Id =1, Name= "Fighting"},
            new{Id =2, Name= "Roleplaying"},
            new{Id =3, Name= "Sports"},
            new{Id =4, Name= "Racing"},
            new{Id =5, Name= "Kids and Family"}
        );
    }
}
