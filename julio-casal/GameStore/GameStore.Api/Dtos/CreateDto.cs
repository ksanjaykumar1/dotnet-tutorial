using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateDto( 
    
    [Required][StringLength(50)]string Name, 
    // [Required][StringLength(20)]string Genre, 
    int GenreId, 
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate); 
