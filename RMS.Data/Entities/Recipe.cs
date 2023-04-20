using System.ComponentModel.DataAnnotations;

namespace RMS.Data.Entities;

public class Recipe
{
    public int Id { get; set; }
    
    // suitable recipe attributes / relationships
    [Required]
    public string Name { get; set; }
    [Required]
    public int PrepTime { get; set; }

    [Required]
    public int CookTime { get; set; }

    [Required]
    public int Servings { get; set; }

    [Required]
    public string DietType { get; set; }

    [Required]
    public string MealCategory { get; set; }

    [Required]
    public string CusineStyle { get; set; }

    [Required]
    public string Carbs { get; set; }

    [Required]
    public string Fat { get; set; }

    [Required]
    public string Protein { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Ingredients { get; set; }

    [Required]
    public string Direction { get; set; }

    [Required]
    public string PhotoUrl { get; set; }

    // Relationship 1-N tickets
    public IList<Review> Reviews {get; set; } = new List<Review>();


 
}


