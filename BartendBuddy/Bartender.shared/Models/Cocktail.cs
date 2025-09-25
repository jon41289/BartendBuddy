using System.ComponentModel.DataAnnotations;
namespace Bartender.shared.Models;

public class Cocktail
{
     [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Name is to short")]
    [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name must contain only alphabets")]
    public string Name { get; set; }
    public int Rating { get; set; }

    [Display(Name = "Main Spirit")]
    public string? MainSpirt { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Flavor is to short")]
    public string? Flavor { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Skill level must be between 1 and 5")]
    [Display(Name = "Skill Level")]
    public int SkillLevel { get; set; }

    public string? Discription { get; set; }

    [Required]
    public string Ingredients { get; set; }

    [Required]
    [MinLength(10, ErrorMessage = "Instructions must be at least 10 characters long")]
    public string? Instructions { get; set; }
    
    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Is Public")]
    public bool IsPublic { get; set; }

    [Display(Name = "Created By")]
    public string CreatedBy { get; set; } = string.Empty;
}
