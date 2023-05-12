using RMS.Data.Entities;
namespace RMS.Data.Services;

public static class ServiceSeeder
{

    // use this method FIRST to seed the database with dummy test data using an IUserService
    public static void Seed(IUserService userSvc, IRecipeService recipeSvc)
    {
        recipeSvc.Initialise();
        
        SeedUsers(userSvc);
        SeedRecipes(recipeSvc);
       
    }

    // use this method FIRST to seed the database with dummy test data using an IUserService
    private static void SeedUsers(IUserService svc)
    {
        // Note: do not call initialise here
        var u1 = svc.Register("admin","admin@mail.com","password",Role.admin);
        var u2 = svc.Register("support","support@mail.com","password",Role.support);
        var u3 = svc.Register("guest","guest@mail.com","password",Role.guest);
      
    }

    // use this method SECOND to seed the database with dummy test data using an IRecipeService
    public static void SeedRecipes(IRecipeService svc)
    {        
        

        // add relevant seed data 
        
        var r1 = svc.AddRecipe( new Recipe {
            Name = "Jollof Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Lunch", 
            CusineStyle = "African", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spicy Orange rice, made with african spices and roasted chicken",
            Ingredients= "Rice, Fresh Tomatoes, seasoning, sacket tomatoes, basil, curry, vegetable oil and chicken",
            Direction = "Rinse rice and boil with tomato, pepper, and spices, Simmer until fully cooked and flavors have melded. Drain the rice and add it to the pot with the sauce. Add water, salt, and bouillon cubes, then bring the mixture to a boil. Reduce the heat to low and simmer for about 20-25 minutes, or until the rice is cooked and the liquid has been absorbed.", 
            PhotoUrl = "https://thumbs.dreamstime.com/b/nigerian-food-party-jollof-rice-fried-chicken-wings-close-nigerian-food-party-jollof-rice-fried-chicken-wings-close-up-112895209.jpg"
        });
       var r2 = svc.AddRecipe( new Recipe {
            Name = "Pancake", PrepTime = 15, CookTime = 5, Servings = 3, DietType = "Vegan", MealCategory = "Breakfast", 
            CusineStyle = "Global", Carbs = "100g", Fat = "20g", Protein = "10g",
            Description = "Delicious round soft dough",
            Ingredients= "Flour, eggs, milk, sugar or honey",
            Direction = "Mix the flour, milk and sugar together \n  Add the eggs and mix thoroughly\n fry vegetable oil in a pan, add you batter and flip each side after 3 mins", 
            PhotoUrl = "https://www.glutenfreepalate.com/wp-content/uploads/2018/07/Gluten-Free-Pancake-Mix-1.2-735x1109.jpg"
        });
        var r3 = svc.AddRecipe( new Recipe {
            Name = "Chinese Rice", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Whole", MealCategory = "Main", 
            CusineStyle = "Asian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Chinese rice is a simple and delicious side dish made from steamed rice, soy sauce, and a variety of vegetables such as carrots, peas, and onions. It is seasoned with garlic, ginger, and sesame oil to give it a fragrant of Chinese main dishes.",
            Ingredients= "rice, water, salt, soy sauce, oil, garlic, ginger, vegetables (such as carrots, peas, and onions), and protein (such as chicken, beef, or shrimp).",
            Direction = "Rinse 2 cups of rice in cold water until the water runs clear.In a medium saucepan, add the rice and 3 cups of water. Bring to a boil over high heat.Reduce the heat to low, cover the saucepan, and let the rice simmer for 18-20 minutes.Remove the saucepan from the heat and let it stand, covered, for 5 minutes.While the rice is cooking, heat 2 tablespoons of vegetable oil in a wok or large skillet over medium-high heat.Add 1 chopped onion.", 
            PhotoUrl = "https://www.everydayeasyeats.com/wp-content/uploads/2016/06/Chinese-Fried-Rice-3.jpg"
        });
        var r4 = svc.AddRecipe( new Recipe {
            Name = "Gluten-Free Lemon cake", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Gluten-free", MealCategory = "Main", 
            CusineStyle = "American", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "This gluten-free lemon cake is a refreshing and zesty treat perfect for any occasion. Made with almond flour and sweetened with honey",
            Ingredients= "1 cup gluten-free all-purpose flour, 1/2 cup almond flour, 1/2 cup granulated sugar, 1/2 cup unsalted butter, softened",
            Direction = "Preheat the oven to 350°F and grease a 9-inch cake pan. In a bowl, whisk together the gluten-free flour, baking powder, and salt.In a separate bowl, mix the sugar, lemon zest, and butter until light and fluffy. Add eggs and lemon juice, then add the flour mixture and mix well. Pour the batter into the prepared pan and bake for 30-35 minutes.", 
            PhotoUrl = "https://www.glutenfreepalate.com/wp-content/uploads/2017/03/Gluten-Free-Lemon-Cake2.2-735x1055.jpg"
        });
        var r5 = svc.AddRecipe( new Recipe {
            Name = "Gluten-free pizza dough(with yeast)", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Gluten-free", MealCategory = "Main", 
            CusineStyle = "Italian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Gluten-free pizza dough is a type of dough used as a substitute for traditional pizza dough made from wheat flour. It is made with a combination of gluten-free flours such as rice flour",
            Ingredients= "1 cup of gluten-free all-purpose flour, 1 teaspoon of xanthan gum, 1 teaspoon of salt, 1 tablespoon of sugar, 1 tablespoon of active dry yeast",
            Direction = "Preheat oven to 425°F (220°C). Roll out the dough to desired thickness and add toppings. Bake for 12-15 minutes or until crust is golden brown and toppings are cooked to desired doneness.", 
            PhotoUrl = "https://fromthelarder.co.uk/wp-content/uploads/2022/06/GF-Pizza-Warm-Images-3.jpg"
        });
       var r6 = svc.AddRecipe( new Recipe {
            Name = "Spagetti Bolognese", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "Italian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Spaghetti bolognese is a classic Italian dish made with spaghetti pasta and a meat-based sauce, usually made with ground beef, tomatoes, onions, and a variety of herbs and spices.",
            Ingredients= "1 pound ground beef, 1 onion, chopped, 2 cloves garlic, minced, 1 can (28 ounces) crushed tomatoes, 1 can (6 ounces) tomato paste, 1 cup beef broth",
            Direction = "Start by cooking spaghetti in a pot of boiling salted water until al dente, according to package instructions. Meanwhile, heat olive oil in a large skillet over medium-high heat. Add ground beef and cook until browned, breaking it up with a wooden spoon as it cooks. Stir in minced garlic, diced onion, diced carrot, and diced celery. Cook for a few minutes until vegetables are softened. Add canned tomatoes, tomato paste, dried oregano, dried basil.", 
            PhotoUrl = "https://www.slimmingeats.com/blog/wp-content/uploads/2010/04/spaghetti-bolognese-33.jpg"
        });

        var r7 = svc.AddRecipe( new Recipe {
            Name = "Chicken curry", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Whole", MealCategory = "Main", 
            CusineStyle = "Indian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Chicken curry is a popular dish in many parts of the world, including India, Thailand, and the Caribbean. The dish typically involves chicken pieces cooked in a spiced tomato-based sauce",
            Ingredients= "1 lb boneless, skinless chicken breast, cut into bite-sized pieces, 1 large onion, diced, 3 cloves garlic, minced, 1 tbsp grated fresh ginger",
            Direction = "Heat some oil in a pan, then add diced onion, garlic, and ginger. Cook until the onion is soft and translucent. Add chicken pieces and cook until they are browned on all sides. Add curry powder, turmeric, cumin, and salt, and stir well to coat the chicken.", 
            PhotoUrl = "https://www.indianhealthyrecipes.com/wp-content/uploads/2021/07/indian-chicken-curry.jpg"
        });

        var r8 = svc.AddRecipe( new Recipe {
            Name = "Asun (Peppered goat meat)", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Whole", MealCategory = "Lunch", 
            CusineStyle = "Nigerian", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "Small chopped spicy delicious goatmeat",
            Ingredients= "1 kg goat meat, cut into bite-sized pieces,3 habanero peppers (or to taste), finely chopped, 1 onion, finely chopped, 2 teaspoons dried thyme, 2 teaspoons dried rosemary",
            Direction = "Preheat your oven to 375°F (190°C). Cut 2 lbs of goat meat into small pieces and marinate with 1 teaspoon of salt, 1 teaspoon of dried pepper flakes, 1 tablespoon of ground crayfish, and 2 tablespoons of vegetable oil. Place the meat in a baking dish and bake in the preheated oven for 25-30 minutes. In a separate pan, heat 2 tablespoons of vegetable oil and fry chopped onions, peppers, and garlic until fragrant. Add the baked goat meat and stir-fry for 5 minutes until well combined. Serve hot with your favorite side dish.", 
            PhotoUrl = "https://lowcarbafrica.com/wp-content/uploads/2019/09/Asun-recipe-homepage.jpg"
        });

        var r9 = svc.AddRecipe( new Recipe {
            Name = "English Breakfast", PrepTime = 20, CookTime = 20, Servings = 3, DietType = "Vegan", MealCategory = "Main", 
            CusineStyle = "English", Carbs = "200g", Fat = "30g", Protein = "10g",
            Description = "English breakfast is a traditional meal commonly eaten in the United Kingdom and Ireland. It usually consists of fried eggs, bacon, sausages, black pudding, baked beans, grilled tomatoes, mushrooms, and toast",
            Ingredients= "Bacon, Sausages, Eggs, Black pudding (a type of blood sausage), Baked beans, Grilled tomatoes",
            Direction = "Fry the bacon and black pudding in a pan until they are cooked to your liking. In another pan, fry the eggs and mushrooms until they are cooked to your liking. You can also grill the tomatoes and sausages. Toast the bread, butter it, and serve with the cooked ingredients.", 
            PhotoUrl = "https://media.istockphoto.com/id/488850023/photo/traditional-full-english-breakfast.jpg?s=612x612&w=0&k=20&c=5RQPChjpXW7aPY_sPxbFhZprjSqBKTiv-SnDVFYOWyo="
        });


        // seed Reviews

        // add Reviews for Jollof
        var re1 = svc.CreateReview(r1.Id, "Mark Smith", "Tasted Good", 3);
        var re2 = svc.CreateReview(r1.Id, "Laila Boom", "It was a bit dry", 2);
        var re3 = svc.CreateReview(r1.Id, "Alice Phil", "It was good but could be better", 3);

        // add Review for Pancakes
        var re4 = svc.CreateReview(r2.Id, "Majorie Job", "I absolutely loved it", 4);

        // add Review for chinese rice 
        var re5 = svc.CreateReview(r3.Id, "Ella Joe", "10/10, would recommend", 5);

    }
}

