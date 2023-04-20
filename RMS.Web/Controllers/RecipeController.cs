using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Data.Entities;
using RMS.Data.Services;
using RMS.Web.Models;

namespace RMS.Web.Controllers;

public class RecipeController : BaseController
{
    // complete
    private IRecipeService svc;

    public RecipeController()
    {
        svc = new RecipeServiceDb();            
    }

    // GET /Recipe
    public IActionResult Index()
    {
        // load recipes using service and pass to view
        var data = svc.GetRecipes();
        
        return View(data);
    }

    // GET /recipes/details/{id}
    public IActionResult Details(int id)
    {
        var recipe = svc.GetRecipe(id);
      
        if (recipe is null) {
            // Alert and Redirect
          Alert("Recipe Was Not Found", AlertType.info);
return RedirectToAction(nameof(Index));
            
        }
        return View(recipe);
    }

    // GET: /recipe/create
    public IActionResult Create()
    {
        // display blank form to create a review
        return View();
    }

    // POST /recipe/create
    [HttpPost]
    public IActionResult Create(Recipe r)
    {   
        //  validate that Name is unique
        if (svc.GetRecipeByName(r.Name) !=null){
          ModelState.AddModelError(nameof(r.Name), "The name already exists");
        }

        // complete POST action to add recipe
        if (ModelState.IsValid)
        {
            // call service AddRecipe method using data in r
            var recipe = svc.AddRecipe(r);
            if (recipe is null) 
            {
                //  using Alert and Redirect
                Alert("Couldn't create Recipe", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Details), new { Id = recipe.Id});   
        }
        
        // redisplay the form for editing as there are validation errors
        return View(r);
    }

    // GET /recipe/edit/{id}
    public IActionResult Edit(int id)
    {
        // load the recipe using the service
        var recipe = svc.GetRecipe(id);

        // check if recipe is null
        if (recipe is null)
        {
            // use Alert and Redirect
            Alert($"Recipe Not Found {id}", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }  

        // pass recipe to view for editing
        return View(recipe);
    }

    // POST /recipe/edit/{id}
    [HttpPost]
    public IActionResult Edit(int id, Recipe r)
    {
        // validation error if Name exists and is not owned by recipe being edited 
        var existing = svc.GetRecipeByName(r.Name);
        if (existing !=null && r.Id != existing.Id)
        {
          ModelState.AddModelError(nameof(r.Name), "This Name is already in use");
        }

        //  POST action to save recipe changes
        if (ModelState.IsValid)
        {            
            var recipe = svc.UpdateRecipe(r);
            //use alert when update failed
            if (recipe is null)
        {
            Alert("Issues updating the recipe", AlertType.warning);
        }

            // redirect back to view the recipe details
            return RedirectToAction(nameof(Details), new { Id = r.Id });
        }

        // redisplay the form for editing as validation errors
        return View(r);
    }

    // GET / recipe/delete/{id}
    public IActionResult Delete(int id)
    {
        // load the recipe using the service
        var recipe = svc.GetRecipe(id);
        // check the returned recipe is not null 
        if (recipe == null)
        {
            // use Alert and Redirect
          Alert("Recipe not found", AlertType.warning);
          return RedirectToAction(nameof(Index));
        }     
        
        // pass review to view for deletion confirmation
        return View(recipe);
    }

    // POST /recipe/delete/{id}
    [HttpPost]
    public IActionResult ConfirmDelete(int id)
    {
        // delete recipe via service
        var deleted = svc.DeleteRecipe(id);
        //  added success / failure Alert
        if (deleted)
      {
          Alert("Recipe deleted", AlertType.success);
      }
        else 
      {
          Alert("Recipe could not  be deleted", AlertType.warning);
      }
        // redirect to the index view
        return RedirectToAction(nameof(Index));
    }

     // ============== Recipe review management ==============

    // GET /recipe/createticket/{id}
    public IActionResult CreateReview(int id)
    {
        var recipe = svc.GetRecipe(id);
        if (recipe == null)
        {
            // Use Alert and Redirect
            Alert("Recipe not found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }

        // create a review view model and set foreign key
        var review = new Review { RecipeId = id }; 
        // render blank form
        return View( review );
    }

    // POST /recipe/createreview
    [HttpPost]
    public IActionResult CreateReview(Review re)
    {
        if (ModelState.IsValid)
        {                
            var review = svc.CreateReview(re.RecipeId, re.Author, re.Comment, re.Rating); 
            // if (review is null) {
            // // Alert and Redirect
            // Alert("Review Was Not Found", AlertType.info);

            // redirect to display Recipe - 
            return RedirectToAction(
                nameof(Details), new { Id = review.RecipeId }
            );
        }
        // redisplay the form for editing
        return View(re);
    }

     public IActionResult ReviewDetails(int id)
    {
        var review = svc.GetReview(id);
      
        if (review is null) {
            // Alert and Redirect
          Alert("Review Was Not Found", AlertType.info);
            return RedirectToAction(nameof(Details));
            
        }
        return View(review);
    }


        // GET /recipe/editReview/{id}
        public IActionResult EditReview(int id)
        {
            var review = svc.GetReview(id);
            if (review == null)
            {
                // use Alert and Redirect
                Alert("Review not found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }        
            return View( review );
        }

    // POST /recipe/editReview
    [HttpPost]
    public IActionResult EditReview(int Id, Review re)
    {
        if (ModelState.IsValid)
        {                
            var review = svc.UpdateReview(Id, re.Comment);
            // TBC - Q2 add alert for success/failure
            if (review is null)
            {
                Alert ("Issues updating review", AlertType.warning);
            }
            // redirect to display student - note how Id is passed
            return RedirectToAction(
                nameof(Details), new { Id = review.RecipeId }
            );
        }
        // redisplay the form for editing
        return View(re);
    }

    // GET /student/ticketdelete/{id}
    public IActionResult DeleteReview(int id)
    {
        // load the review using the service
        var review = svc.GetReview(id);
        // check the returned Review is not null
        if (review == null)
        {
            // use Alert and Redirect
            Alert("Review not found", AlertType.warning);
            return RedirectToAction(nameof(Index));;
        }     
        
        // pass review to view for deletion confirmation
        return View(review);
    }

    // POST /recipe/deletereviewconfirm/{id}
    [HttpPost]
    public IActionResult DeleteReviewConfirm(int id, int recipeId)
    {
        var deleted = svc.DeleteReview(id);

        //  success/failure alert
        if (deleted)
        {
            Alert("Review deleted successful", AlertType.success);
        }
        else 
        {
            Alert("Review could not  be deleted", AlertType.warning);
        }

        // redirect to the recipe details view
        return RedirectToAction(nameof(Details), new { Id = recipeId });
    }

}


