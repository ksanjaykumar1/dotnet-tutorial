using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGames";

    // Its readonly because we are never going to create the entire List from scratch
    private static readonly List<GameDto> games = [
        new (1, "Elden Ring", "RPG", 59.99m, new DateOnly(2022, 2, 25)),
        new (2, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
        new (3, "Cyberpunk 2077", "Action RPG", 39.99m, new DateOnly(2020, 12, 10)),
        new (4, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");
        // GET /games
        group.MapGet("", ()=> games);

        // GET by ID /games/id
        group.MapGet("/{id}",(int id) =>{ 
            GameDto? game = games.Find(game => game.Id == id);
                return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateDto newGame)=>{
            GameDto game = new(games.Count +1 , newGame.Name, newGame.Genre,  newGame.Price, newGame.ReleaseDate);
            games.Add(game);
            
            return Results.CreatedAtRoute(GetGameEndpointName, new {id= game.Id}, game);
        });

        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame)=>{
            var index = games.FindIndex(game=> game.Id == id);

            if(index ==-1){
            return Results.NotFound(); 
            }

            games[index] = new GameDto(id, updatedGame.Name, updatedGame.Genre, updatedGame.Price, updatedGame.ReleaseDate);
            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id)=>{
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });

        return group;

    }

}
