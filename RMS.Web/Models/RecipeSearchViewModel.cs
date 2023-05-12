using RMS.Data.Entities;

namespace RMS.Web.Models;


public class RecipeSearchViewModel
{
    // results which is a list of Recipes
  public IList<Recipe> Recipes { get; set; } = new List<Recipe>();
       
    // query which is a string        
  public string Query { get; set; } = "";

    // range - a recipe range that defaults to RecipeRange.ALL
  public RecipeRange Range { get; set; } = RecipeRange.ALL;

  public string OrderBy { get; set; } = "id";
  public string Direction { get; set; } = "asc";
}