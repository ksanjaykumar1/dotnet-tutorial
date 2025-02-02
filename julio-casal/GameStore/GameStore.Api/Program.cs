using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGames";

List<GameDto> games = [
    new (1, "Elden Ring", "RPG", 59.99m, new DateOnly(2022, 2, 25)),
    new (2, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
    new (3, "Cyberpunk 2077", "Action RPG", 39.99m, new DateOnly(2020, 12, 10)),
    new (4, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19))
];

// GET /games
app.MapGet("games", ()=> games);

// GET by ID /games/id
app.MapGet("games/{id}",(int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndpointName);

// POST /games
app.MapPost("games", (CreateDto newGame)=>{
    GameDto game = new(games.Count +1 , newGame.Name, newGame.Genre,  newGame.Price, newGame.ReleaseDate);
    games.Add(game);
    
    return Results.CreatedAtRoute(GetGameEndpointName, new {id= game.Id}, game);
});

// PUT /games
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame)=>{
    var index = games.FindIndex(game=> game.Id == id);

    games[index] = new GameDto(id, updatedGame.Name, updatedGame.Genre, updatedGame.Price, updatedGame.ReleaseDate);
    return Results.NoContent();
});

// DELETE /games/1
app.MapDelete("games/{id}", (int id)=>{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});


app.Run();
