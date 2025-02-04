using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

// Creating Extension Method to CreateDto
public static class GameMapping
{
    /* ToEntity is an extension method that adds functionality to the CreateGameDto type.
        this CreateGameDto game:
            1. This makes ToEntity() an extension method on CreateGameDto.
            2. It allows you to call game.ToEntity() on any CreateGameDto object. 
    */
    public static Game ToEntity(this CreateDto game){
        return  new Game(){
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static GameDto ToDto(this Game game)
    {
            return new(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);
    }

}
