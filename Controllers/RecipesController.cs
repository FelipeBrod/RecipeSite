using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    public class RecipesController : Controller
    {
        private IRecipeRepository repository;
        public int PageSize = 10;
        public RecipesController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult RecipeList(int recipePage = 1) => View(new RecipesListViewModel
        {
            Recipes = repository.Recipes
                .OrderBy(p => p.Id)
                .Skip((recipePage - 1) * PageSize)
                .Take(PageSize),
                 PagingInfo = new PagingInfo //not working
            {
                CurrentPage = recipePage,
                RecipesPerPage = PageSize,
                TotalRecipes = repository.Recipes.Count()
            }
        });

        
      

        [HttpGet]
        public IActionResult ReviewRecipe()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ViewRecipe(int id)
        {
            Recipe recipe = repository.Recipes.Where(n => n.Id == id).FirstOrDefault();
            return View(recipe);
        }[HttpGet]
        public ViewResult RecipeReviews(int id)
        {
            Recipe recipe = repository.Recipes.Where(n => n.Id == id).FirstOrDefault();
            return View(recipe);
        }

    }
}