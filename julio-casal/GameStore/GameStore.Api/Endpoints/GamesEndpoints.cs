using System;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGames";

    // Its readonly because we are never going to create the entire List from scratch
    private static readonly List<GameSummaryDto> games = [
        new (1, "Elden Ring", "RPG", 59.99m, new DateOnly(2022, 2, 25)),
        new (2, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
        new (3, "Cyberpunk 2077", "Action RPG", 39.99m, new DateOnly(2020, 12, 10)),
        new (4, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
                        .WithParameterValidation();
        // GET /games
        group.MapGet("", (GameStoreContext dbContext)=> 
            dbContext.Games
                     .Include(game => game.Genre)
                     .Select(game => game.ToGameSummaryDto())
                     .AsNoTracking());

        // GET by ID /games/id
        group.MapGet("/{id}",(int id,  GameStoreContext dbContext) =>{ 
            Game? game = dbContext.Games.Find(id);
                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
            })
            .WithName(GetGameEndpointName);
        // POST /games
        group.MapPost("/", (CreateDto newGame, GameStoreContext dbContext)=>{
            Game game = newGame.ToEntity();
            dbContext.Games.Add(game);
            dbContext.SaveChanges();
            return Results.CreatedAtRoute(GetGameEndpointName, new {id= game.Id}, game.ToGameDetailsDto());
        });
        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext)=>{

            var existingGame = dbContext.Games.Find(id);

            if (existingGame is null){
                return Results.NotFound();                 
            }
            
            dbContext.Entry(existingGame)
                     .CurrentValues
                     .SetValues(updatedGame.ToEntity(id));
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext)=>{
            dbContext.Games.Where(game => game.Id ==id)
                            .ExecuteDelete();
            return Results.NoContent();
        });

        return group;

    }

}
