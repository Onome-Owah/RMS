using Microsoft.EntityFrameworkCore;
using RMS.Data.Entities;
using RMS.Data.Repository;

namespace RMS.Data.Services;

// EntityFramework Implementation of IRecipeService
public class RecipeServiceDb : IRecipeService
{
    private readonly DataContext db;

    public RecipeServiceDb()
    {
        db = new DataContext();
    }

    public void Initialise()
    {
        db.Initialise(); // recreate database
    }

    // ==================== Recipe Management ==================

    // implement IRecipeService methods here

    // retrieve list of Recipes
    public List<Recipe> GetRecipes(string order="id", string direction="asc")
    {
        var query = db.Recipes;
        var results = (order.ToLower(), direction.ToLower()) switch
        {   
            ("id", "asc")     => db.Recipes.OrderBy(r => r.Id),     
            ("Name", "asc")   => db.Recipes.OrderBy(r => r.Name),  
            ("Name", "desc")   => db.Recipes.OrderByDescending(r => r.Name),   
            ("DietType", "asc")  => db.Recipes.OrderBy(r => r.DietType),
            ("DietType", "desc")  => db.Recipes.OrderByDescending(r => r.DietType),      
            ("Cuisine", "asc")    => db.Recipes.OrderBy(r => r.CusineStyle),   
            ("Cuisine", "desc")    => db.Recipes.OrderByDescending(r => r.CusineStyle),     
            (_,_)        => db.Recipes.OrderBy(r => r.Id)
        };
        return results.ToList();
    }


    // Retrive Recipe by Id 
    public Recipe GetRecipe(int id)
    {
        return db.Recipes
                 .Include(r => r.Reviews)
                 .FirstOrDefault(r => r.Id == id);
    }

    // Add a new Recipe
    public Recipe AddRecipe(Recipe r)
    {
        // check if Recipe with Name exists            
        var exists = GetRecipeByName(r.Name);
        if (exists != null)
        {
            return null;
        }

        // create new Recipe
        var recipe = new Recipe
        {
            Name = r.Name,
            PrepTime = r.PrepTime,
            CookTime = r.CookTime,
            Servings = r.Servings,
            DietType = r.DietType,
            MealCategory = r.MealCategory,
            CusineStyle = r.CusineStyle,
            Carbs = r.Carbs,
            Fat = r.Fat,
            Protein = r.Protein,
            Description = r.Description,
            Ingredients = r.Ingredients,
            Direction = r.Direction,
            PhotoUrl = r.PhotoUrl
        };
        db.Recipes.Add(recipe); // add recipe to the list
        db.SaveChanges();
        return recipe; // return newly added recipe
    }

    // Delete the recipe identified by Id returning true if 
    // deleted and false if not found
    public bool DeleteRecipe(int id)
    {
        var r = GetRecipe(id);
        if (r == null)
        {
            return false;
        }
        db.Recipes.Remove(r);
        db.SaveChanges();
        return true;
    }

    // Update the Recipe with the details in updated 
    public Recipe UpdateRecipe(Recipe updated)
    {
        // verify the recipe exists 
        var recipe = GetRecipe(updated.Id);
        if (recipe == null)
        {
            return null;
        }

        // verify recipe name is still unique
        var exists = GetRecipeByName(updated.Name);
        if (exists != null && exists.Id != updated.Id)
        {
            return null;
        }


        // update the details of the recipe retrieved and save
        recipe.Name = updated.Name;
        recipe.PrepTime = updated.PrepTime;
        recipe.CookTime = updated.CookTime;
        recipe.Servings = updated.Servings;
        recipe.DietType = updated.DietType;
        recipe.MealCategory = updated.MealCategory;
        recipe.CusineStyle = updated.CusineStyle;
        recipe.Carbs = updated.Carbs;
        recipe.Fat = updated.Fat;
        recipe.Protein = updated.Protein;
        recipe.Description = updated.Description;
        recipe.Ingredients = updated.Ingredients;
        recipe.Direction = updated.Direction;
        recipe.PhotoUrl = updated.PhotoUrl;

        db.SaveChanges();
        return recipe;
    }

    public Recipe GetRecipeByName(string name)
    {
        return db.Recipes.FirstOrDefault(r => r.Name == name);
    }

    // ===================== Review Management ==========================
    public Review CreateReview(int recipeId, string author, string comment, int rating)
    {
        var recipe = GetRecipe(recipeId);
        if (recipe == null) return null;

        var review = new Review
        {
            // Id created by Database
            Author = author,
            Comment = comment,
            Rating = rating,
            RecipeId = recipeId,
            // set by default in model but we can override here if required
            CreatedOn = DateTime.Now,

        };
        db.Reviews.Add(review);
        db.SaveChanges(); // write to database
        return review;
    }

    public Review UpdateReview(int id, string comment)
    {
        var review = GetReview(id);
        if (review == null) return null;

        review.Comment = comment;

        db.Reviews.Update(review);
        db.SaveChanges(); // write to database
        return review;
    }

    public Review GetReview(int id)
    {
        // return reviews and related recipe or null if not found
        return db.Reviews
                    .Include(re => re.Recipe)
                    .FirstOrDefault(re => re.Id == id);
    }


    public bool DeleteReview(int id)
    {
        // find review
        var review = GetReview(id);
        if (review == null) return false;

        // remove Remove
        var result = db.Reviews.Remove(review);

        db.SaveChanges();
        return true;
    }

    // Retrieve all reviews and the recipe associated with the review
        public IList<Recipe> GetAllRecipes()
        {
            return db.Recipes
                     .Include(r => r.Reviews)
                     .ToList();
        }

    // perform a search of the reviews based on a query and an active range 'ALL'
        public IList<Recipe> SearchRecipes(RecipeRange range, string query, string orderBy="id", string direction="asc") 
        {
                        
          query = query == null ? "" : query.ToLower();

          var search = db.Recipes
                          .Include(r => r.Reviews)
                          .Where(r => (r.Name.ToLower().Contains(query) ||
                            r.MealCategory.ToLower().Contains(query) ||
                            r.CusineStyle.ToLower().Contains(query) 
                            ) 
                );
                            
          return Ordered(search, orderBy, direction).ToList();        
        }

        private IQueryable<Recipe> Ordered(IQueryable<Recipe> query, string orderby, string direction)
        {
            query = (orderby,direction) switch {
                ("id", "asc") => query.OrderBy(re => re.Id),
                ("id", "desc") => query.OrderByDescending(re => re.Id),
                ("name", "asc") => query.OrderBy(re => re.Name),
                ("name", "desc") => query.OrderByDescending(re => re.Name),
                  
                _ => query
            };
            return query;
        }

}

