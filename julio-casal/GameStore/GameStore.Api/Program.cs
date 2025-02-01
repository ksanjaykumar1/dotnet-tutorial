using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (1, "Elden Ring", "RPG", 59.99m, new DateOnly(2022, 2, 25)),
    new (2, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
    new (3, "Cyberpunk 2077", "Action RPG", 39.99m, new DateOnly(2020, 12, 10)),
    new (4, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19))
];

// GET /games
app.MapGet("games", ()=> games);


app.Run();
