using System;
using Bartender.shared.Models;
using Refit;

namespace Bartender.shared.IRepositories;

public interface ICocktailRepository
{
    [Get("/api/Cocktail")]
    Task<List<Cocktail>> GetAllCocktailsAsync();

    [Get("/api/Cocktail/{id}")]
    Task<Cocktail?> GetCocktailByIdAsync(int id);

    [Post("/api/Cocktail")]   
    Task<Cocktail> CreateCocktailAsync(Cocktail cocktail);

    [Put("/api/Cocktaiil/{id}")]
    Task<Cocktail> UpdateCocktailAsync(int id, Cocktail updatedCocktail);

    [Delete("/api/Cocktail/{id}")]
    Task<Cocktail?> DeleteCocktailAsync(int id);
}
