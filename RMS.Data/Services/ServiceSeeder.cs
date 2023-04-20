using RMS.Data.Entities;
namespace RMS.Data.Services;

public static class ServiceSeeder
{

    // use this method FIRST to seed the database with dummy test data using an IUserService
    public static void SeedUsers(IUserService svc)
    {
        svc.Initialise();
        svc.Register("admin","admin@mail.com","password",Role.admin);
       
    }
    
    // use this method SECOND to seed the database with dummy test data using an IRecipeService
    public static void SeedRecipes(IRecipeService svc)
    {        
        

        // add relevant seed data 
         // seed recipes
        
        var r1 = svc.AddRecipe( new Recipe {
            Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Lunch", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato", 
            PhotoUrl = "https://thumbs.dreamstime.com/b/nigerian-food-party-jollof-rice-fried-chicken-wings-close-nigerian-food-party-jollof-rice-fried-chicken-wings-close-up-112895209.jpg"
        });
       var r2 = svc.AddRecipe( new Recipe {
            Name = "Pancake", PrepTime = 15, CookTime = 5, Servings = 3, DietType = "Vegan", MealCategory = "Breakfast", 
            CusineStyle = "Global", Carbs = "100g", Fat = "20g", Protein = "10g",
            Description = "Delious round soft dough",
            Ingredients= "Flour, eggs, milk, sugar or honey",
            Direction = "Mix the flour, milk and sugar together \n  Add the eggs and mix thoroughly\n fry vegetable oil in a pan, add you batter and flip each side after 3 mins", 
            PhotoUrl = "https://www.glutenfreepalate.com/wp-content/uploads/2018/07/Gluten-Free-Pancake-Mix-1.2-735x1109.jpg"
        });
        var r3 = svc.AddRecipe( new Recipe {
            Name = "Chinese Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Whole", MealCategory = "Main", 
            CusineStyle = "Asian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://www.everydayeasyeats.com/wp-content/uploads/2016/06/Chinese-Fried-Rice-3.jpg"
        });
        var r4 = svc.AddRecipe( new Recipe {
            Name = "Gluten-Free Lemon cake", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://www.glutenfreepalate.com/wp-content/uploads/2017/03/Gluten-Free-Lemon-Cake2.2-735x1055.jpg"
        });
        var r5 = svc.AddRecipe( new Recipe {
            Name = "Gluten-free pizza dough(with yeast)", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "Italian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://fromthelarder.co.uk/wp-content/uploads/2022/06/GF-Pizza-Warm-Images-3.jpg"
        });
       var r6 = svc.AddRecipe( new Recipe {
            Name = "Spagetti Bolognese", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "Italian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://www.slimmingeats.com/blog/wp-content/uploads/2010/04/spaghetti-bolognese-33.jpg"
        });

        var r7 = svc.AddRecipe( new Recipe {
            Name = "Chicken curry", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Whole", MealCategory = "Main", 
            CusineStyle = "Indian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://www.indianhealthyrecipes.com/wp-content/uploads/2021/07/indian-chicken-curry.jpg"
        });

        var r8 = svc.AddRecipe( new Recipe {
            Name = "Asun (Peppered goat meat)", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Whole", MealCategory = "Lunch", 
            CusineStyle = "Nigerian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Small chopped spicy delicious goatmeat",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://lowcarbafrica.com/wp-content/uploads/2019/09/Asun-recipe-homepage.jpg"
        });

        var r9 = svc.AddRecipe( new Recipe {
            Name = "English Breakfast", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "English", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Maybe the most popular dish in West Africa, this recipe for rice infused in a rich tomato-pepper broth is unifying and dividing all at once, with everyone claiming their take on it as the definitive version. Ours takes the best flavours with the addition of charring the peppers in the recipe before puréeing, to help add a smokiness to this jollof ‘party’ rice. If you’d rather keep it more traditional, skip the roasting and just use raw peppers instead", 
            PhotoUrl = "https://media.istockphoto.com/id/488850023/photo/traditional-full-english-breakfast.jpg?s=612x612&w=0&k=20&c=5RQPChjpXW7aPY_sPxbFhZprjSqBKTiv-SnDVFYOWyo="
        });


        // seed Reviews

        // add Reviews for Jollof
        var re1 = svc.CreateReview(r1.Id, "Mark Smith", "Tasted Good", 8);
        var re2 = svc.CreateReview(r1.Id, "Laila Boom", "It was a bit dry", 5);
        var re3 = svc.CreateReview(r1.Id, "Alice Phil", "It was good but could be better", 6);

        // add Review for Pancakes
        var re4 = svc.CreateReview(r2.Id, "Majorie Job", "I absolutely loved it", 4);

        // add Review for chinese rice 
        var re5 = svc.CreateReview(r3.Id, "Ella Joe", "Can never be me", 7);
        
        


    }
}

