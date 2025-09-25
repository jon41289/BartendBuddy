using Bartender.shared.IRepositories;
using Bartender.shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BartendBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailController : ControllerBase
    {
        private readonly ICocktailRepository cocktailRepository;
        public CocktailController(ICocktailRepository cocktailRepository)
        {
            this.cocktailRepository = cocktailRepository;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetCocktails()
        {
            var cocktails = await cocktailRepository.GetAllCocktailsAsync();
            return Ok(cocktails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCocktail([FromRoute] int id)
        {
            var cocktail = await cocktailRepository.GetCocktailByIdAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }
            return Ok(cocktail);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCocktail([FromBody] Cocktail cocktail)
        {
            await cocktailRepository.CreateCocktailAsync(cocktail);
            return CreatedAtAction(nameof(GetCocktail), new { id = cocktail.Id }, cocktail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCocktail([FromRoute] int id, [FromBody] Cocktail updatedCocktail)
        {
            var cocktail = await cocktailRepository.UpdateCocktailAsync(id, updatedCocktail);
            
            if (cocktail == null)
            {
                return NotFound();
            }
            return Ok(cocktail);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCocktail([FromRoute] int id)
        {
            var cocktail = await cocktailRepository.DeleteCocktailAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }

    
            return NoContent();
        }

    }
}
