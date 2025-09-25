using System;
using BartendBuddy.Data;
using Bartender.shared.IRepositories;
using Bartender.shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BartendBuddy.Repositories;

public class CocktailRepository : ICocktailRepository
{
    private readonly ApplicationDbContext _context;

    public CocktailRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cocktail> CreateCocktailAsync(Cocktail cocktail)
    {
        await _context.Cocktails.AddAsync(cocktail);
        await _context.SaveChangesAsync();
        return cocktail;
    }

    public async Task<Cocktail?> DeleteCocktailAsync(int id)
    {

        var cocktail = await _context.Cocktails.FirstOrDefaultAsync(c => c.Id == id);
        if (cocktail == null)
        {
            return null;
        }
        _context.Cocktails.Remove(cocktail);
        await _context.SaveChangesAsync();
        return cocktail;
    }


    public async Task<List<Cocktail>> GetAllCocktailsAsync()
    {
        return await _context.Cocktails.ToListAsync();
    }

    public async Task<Cocktail?> GetCocktailByIdAsync(int id)
    {
        return await _context.Cocktails.FindAsync(id);
    }

    public async Task<Cocktail> UpdateCocktailAsync(int id, Cocktail updatedCocktail)
    {
        var cocktail = await _context.Cocktails.FirstOrDefaultAsync(c => c.Id == id);
        if (cocktail == null)
        {
            return null;
        }

        cocktail.Name = updatedCocktail.Name;
        cocktail.Ingredients = updatedCocktail.Ingredients;
        cocktail.Instructions = updatedCocktail.Instructions;
        cocktail.MainSpirt = updatedCocktail.MainSpirt;
        cocktail.Flavor = updatedCocktail.Flavor;
        cocktail.Rating = updatedCocktail.Rating;
        cocktail.SkillLevel = updatedCocktail.SkillLevel;

        return cocktail;
    }
}
