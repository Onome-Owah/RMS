
using Xunit;
using RMS.Data.Entities;
using RMS.Data.Services;

namespace RMS.Test;

// ==================== RecipeService Tests =============================
[Collection("Sequential")]
public class RecipeServiceTests
{
    private readonly IRecipeService svc;

    public RecipeServiceTests()
    {
        // general arrangement
        svc = new RecipeServiceDb();
        
        // ensure data source is empty before each test
        svc.Initialise();
    }

    // ========================== TBC Recipe Tests  =========================
     // =========================== GET ALL RECIPE TESTS =================================

    [Fact] 
    public void GetAllRecipes_WhenNoneExist_ShouldReturn0()
    {
        // act 
        var recipes = svc.GetRecipes();
        var count = recipes.Count;

        // assert
        Assert.Equal(0, count);
    }

    [Fact]
    public void GetRecipes_With2Added_ShouldReturnCount2()
    {
        // arrange       
        var r1 = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        var r2 = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead",  }
        );       

        // act
        var recipes = svc.GetRecipes();
        var count = recipes.Count;

        // assert
        Assert.Equal(2, count);
    }

    // =========================== GET SINGLE RECIPE TESTS =================================

    [Fact] 
    public void GetRecipe_WhenNoneExist_ShouldReturnNull()
    {
        // act 
        var recipe = svc.GetRecipe(1); // non existent student

        // assert
        Assert.Null(recipe);
    }

    [Fact] 
    public void GetRecipe_WhenAdded_ShouldReturnRecipe()
    {
        // arrange 
        var r = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead",  }
        );

        // act
        var nrecipe = svc.GetRecipe(r.Id);

        // assert
        Assert.NotNull(nrecipe);
        Assert.Equal(r.Id, nrecipe.Id);
    }

    [Fact] 
    public void GetRecipe_WithReviews_RetrievesRecipeAndReviews()
    {
        // arrange
        var r = svc.AddRecipe( 
            new Recipe { Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        svc.CreateReview(r.Id, "Mark Smith", "Tasted Good", 8);  

        // act      
        var nrecipe = svc.GetRecipe(r.Id);
        
        // assert
        Assert.NotNull(nrecipe);
        Assert.Equal(1, nrecipe.Reviews.Count);
  } 


    [Fact] 
    public void GetRecipeByName_WhenAdded_ShouldReturnRecipe()
    {
        // arrange 
        var r = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );

        // act
        var nrecipe = svc.GetRecipeByName("Jollof Rice");

        // assert
        Assert.NotNull(nrecipe);
        Assert.Equal(r.Name, nrecipe.Name);
    }

    // =========================== ADD RECIPE TESTS =================================

    [Fact]
    public void AddRecipe_WhenValid_ShouldAddRecipe()
    {
        // arrange - add new recipe
        var added = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        
        // act - try to retrieve the newly added recipe
        var r = svc.GetRecipe(added.Id);

        // assert - that recipe is not null
        Assert.NotNull(r);
        
        // now assert that the properties were set properly
        Assert.Equal(r.Id, r.Id);
        Assert.Equal("Jollof Rice", r.Name);
        Assert.Equal(20, r.PrepTime);
        Assert.Equal(20, r.CookTime);
        Assert.Equal(3, r.Servings);
        Assert.Equal("Vegan", r.DietType);
        Assert.Equal("Main", r.MealCategory);
        Assert.Equal("African", r.CusineStyle);
        Assert.Equal("200g", r.Carbs);
        Assert.Equal("30g", r.Fat);
        Assert.Equal("10g", r.Protein);
        Assert.Equal("Spicy Orange rice, made with african spices and roasted chicken", r.Description);
        Assert.Equal("Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", r.Direction);
        
    }

    [Fact] // --- AddRecipe Duplicate Test
    public void AddRecipe_WhenDuplicateName_ShouldReturnNull()
    {
        // arrange
        var r1 = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );

        // act 
        var r2 = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead",  }
        );
        
        // assert
        Assert.NotNull(r1);
        Assert.Null(r2);       
    }

    // =========================== UPDATE RECIPE TESTS =================================

    [Fact]
    public void UpdateRecipe_ThatExists_ShouldSetAllProperties()
    {
        // arrange - create test recipe        
        var r = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
                              
        // act - ** create a copy and update all student properties (except Id) **
        var ud = svc.UpdateRecipe(           
            new Recipe {
                Id = r.Id, // use original Id
                Name = "jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
                CusineStyle = "African", Carbs = "200g", Fat = "40g", Protein = "10g",
                Description = "white rice, made with water and salt",
                Ingredients= "Rice, water and salt",
                Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead"
            }
        ); 

        // reload updated recipe from database into new student object (us)
        var urecipe = svc.GetRecipe(r.Id);

        // assert
        Assert.NotNull(urecipe);           

        // now assert that the properties were set properly           
        Assert.Equal(r.Name, urecipe.Name);
        Assert.Equal(r.PrepTime, urecipe.PrepTime);
        Assert.Equal(r.CookTime, urecipe.CookTime);
        Assert.Equal(r.Servings, urecipe.Servings);
        Assert.Equal(r.DietType, urecipe.DietType);
        Assert.Equal(r.MealCategory, urecipe.MealCategory);
        Assert.Equal(r.CusineStyle, urecipe.CusineStyle);
        Assert.Equal(r.Carbs, urecipe.Carbs);
        Assert.Equal(r.Fat, urecipe.Fat);
        Assert.Equal(r.Protein, urecipe.Protein);
        Assert.Equal(r.Description, urecipe.Description);
        Assert.Equal(r.Ingredients, urecipe.Ingredients);
        Assert.Equal(r.Direction, urecipe.Direction);
    }

    
    [Fact]
    public void UpdateRecipe_WhenDuplicateName_ShouldReturnNull()
    {
        // arrange
        var r1 = svc.AddRecipe(
            new Recipe { Name = "Jollof Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead"  }
        );
        var r2 = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", }
        );

        // act - update r2 Name with duplicate value from r1
        var updated = svc.UpdateRecipe(
            new Recipe { Name = r1.Name, Id = r2.Id, PrepTime=r2.PrepTime, CookTime=r2.CookTime, Servings=r2.Servings, DietType=r2.DietType,
                         MealCategory = r2.MealCategory, CusineStyle = r2.CusineStyle, Carbs = r2.Carbs, Fat = r2.Fat, Protein = r2.Protein,
                         Description = r2.Description, Ingredients = r2.Ingredients, Direction = r2.Description }    
        );
        
        // assert
        Assert.NotNull(r1);
        Assert.NotNull(r2);
        Assert.Null(updated);
    }

    // ===========================  DELETE RECIPE TESTS =================================
    [Fact]
    public void DeleteRecipe_ThatExists_ShouldReturnTrue()
    {
        // arrange 
        var r = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
       
        // act
        var deleted = svc.DeleteRecipe(r.Id);

        // try to retrieve deleted recipe
        var r1 = svc.GetRecipe(r.Id);

        // assert
        Assert.True(deleted); // delete recipe should return true
        Assert.Null(r1);      // s1 should be null
    }


    [Fact]
    public void DeleteRecipe_ThatDoesntExist_ShouldReturnFalse()
    {
        // act 	
        var deleted = svc.DeleteRecipe(0);

        // assert
        Assert.False(deleted);
    }  


    // ---------------------- Reviews Tests ------------------------
        
    [Fact] 
    public void CreateReview_ForExistingRecipe_ShouldBeCreated()
    {
        // arrange
         var r = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        // act
        var re = svc.CreateReview(r.Id, "Mark Smith", "Tasted Good", 8);
        
        // assert
        Assert.NotNull(re);
        Assert.Equal(r.Id, re.RecipeId);
    }

    [Fact] // --- GetReview should include Recipe
    public void GetReviews_WhenExists_ShouldReturnReviewAndRecipe()
    {
        // arrange
        var r = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        var re = svc.CreateReview(r.Id, "Mark Smith", "Tasted Good", 8);

        // act
        var review = svc.GetReview(re.Id);

        // assert
        Assert.NotNull(review);
        Assert.NotNull(review.Recipe);
        Assert.Equal(r.Name, review.Recipe.Name); 
    }


    [Fact] 
    public void DeleteReview_WhenExists_ShouldReturnTrue()
    {
        // arrange
         var r = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        var re = svc.CreateReview(r.Id, "Mark Smith", "Tasted Good", 8);

        // act
        var deleted = svc.DeleteReview(re.Id);     // delete review  
        
        // assert
        Assert.True(deleted);                    // review should be deleted
    }  
 

    [Fact] 
    public void DeleteReview_WhenNonExistant_ShouldReturnFalse()
    {
        // arrange
        
        // act
        var deleted = svc.DeleteReview(1);     // delete non-existent review   
        
        // assert
        Assert.False(deleted);                  // review should not be deleted
    }  

    [Fact] 
    public void DeleteReview_WhenValid_ShouldBeRemovedFromRecipe()
    {
        // arrange
         var r = svc.AddRecipe(
            new Recipe { Name = "white Rice", PrepTime = 10, CookTime = 10, Servings = 2, DietType = "whole", MealCategory = "Main", 
            CusineStyle = "Chinese", Carbs = "100g", Fat = "20g", Protein = "20g",
            Description = "white rice, made with water and salt",
            Ingredients= "Rice, water and salt",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead" }
        );
        var re = svc.CreateReview(r.Id, "Mark Smith", "Tasted Good", 8);

        // act
        svc.DeleteReview(re.Id);        // delete the review
        var nrecipe = svc.GetRecipe(r.Id); // reload the recipe

        // assert
        Assert.NotNull(nrecipe);
        Assert.Equal(0, nrecipe.Reviews.Count);
    }
    
}

// ==================== UserService Tests =============================
[Collection("Sequential")]
public class UserServiceTests
{
    private readonly IUserService svc;

    public UserServiceTests()
    {
        // general arrangement
        svc = new UserServiceDb();
        
        // ensure data source is empty before each test
        svc.Initialise();
    }

    // ========================== User Tests =========================

    [Fact] // --- Register Valid User test
    public void User_Register_WhenValid_ShouldReturnUser()
    {
        // arrange 
        var reg = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
        
        // act
        var user = svc.GetUserByEmail(reg.Email);
        
        // assert
        Assert.NotNull(reg);
        Assert.NotNull(user);
    } 

    [Fact] // --- Register Duplicate Test
    public void User_Register_WhenDuplicateEmail_ShouldReturnNull()
    {
        // arrange 
        var s1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
        
        // act
        var s2 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);

        // assert
        Assert.NotNull(s1);
        Assert.Null(s2);
    } 

    [Fact] // --- Authenticate Invalid Test
    public void User_Authenticate_WhenInValidCredentials_ShouldReturnNull()
    {
        // arrange 
        var s1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
    
        // act
        var user = svc.Authenticate("xxx@email.com", "guest");
        // assert
        Assert.Null(user);

    } 

    [Fact] // --- Authenticate Valid Test
    public void User_Authenticate_WhenValidCredentials_ShouldReturnUser()
    {
        // arrange 
        var s1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
    
        // act
        var user = svc.Authenticate("xxx@email.com", "admin");
        
        // assert
        Assert.NotNull(user);
    } 
 
}
