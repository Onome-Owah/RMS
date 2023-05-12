using System;
using System.Collections.Generic;
	
using RMS.Data.Entities;
	
namespace RMS.Data.Services;

// This interface describes the operations that a RecipeService class should implement
public interface IRecipeService
{
    void Initialise();
        
    // add suitable method definitions to implement assignment requirements            
    
    // ---------------- Recipe Management --------------
    List<Recipe> GetRecipes(string order="id", string direction="asc");
    Recipe GetRecipe(int id);
    Recipe GetRecipeByName(string name);
    Recipe AddRecipe(Recipe r);
    Recipe UpdateRecipe(Recipe updated);  
    bool DeleteRecipe(int id);
  

    // ---------------- Review Management ---------------
    Review CreateReview(int RecipeId, string author, string comment, int id);
    Review UpdateReview(int id, string comment);
    Review GetReview(int id);
    bool   DeleteReview(int id);
    IList<Recipe> GetAllRecipes();     
    IList<Recipe> SearchRecipes(RecipeRange range, string query, string orderBy="id", string direction="asc");

}
    
