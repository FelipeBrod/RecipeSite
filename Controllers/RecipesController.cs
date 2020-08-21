using Microsoft.AspNetCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _repository;
        private readonly ICuisineRepository _CuisineRepository;
        

        public RecipesController(IRecipeRepository repo, ICuisineRepository cuisineRepo)
        {
            _repository = repo;
            _CuisineRepository = cuisineRepo;
        }
        public IActionResult RecipeList()
        {
            var list = new RecipesListViewModel
            {
                Recipes = _repository.GetRecipes().ToList(),
                Cuisines = _CuisineRepository.FindAll()
            };

            return View(list);

        }





        [HttpGet]
        public IActionResult ReviewRecipe()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ViewRecipe(int id)
        {
            var getRecipeId = _repository.FindById(id);

            var recipe = new RecipesListViewModel
            {
                Recipe = getRecipeId,
                Cuisine = _CuisineRepository.FindById(getRecipeId.CuisineId)
            };

            return View(recipe);
        }
    }
}