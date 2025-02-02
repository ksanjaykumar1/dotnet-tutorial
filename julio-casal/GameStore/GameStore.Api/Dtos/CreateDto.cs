namespace GameStore.Api.Dtos;

public record class CreateDto( 
    string Name, 
    string Genre, 
    decimal Price,
    DateOnly ReleaseDate);
