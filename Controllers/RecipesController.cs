using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _repository;
        private readonly ICuisineRepository _CuisineRepository;
        public int PageSize = 10;

        public RecipesController(IRecipeRepository repo, ICuisineRepository cuisineRepo)
        {
            _repository = repo;
            _CuisineRepository = cuisineRepo;
        }
        public IActionResult RecipeList()
        {
            var list = _repository.FindAllRecipes;
            return View(list);

        }

        //View(new RecipesListViewModel
        //{
        //    Recipes = repository.Recipes
        //    .OrderBy(p => p.Id)
        //    .Skip((recipePage - 1) * PageSize)
        //    .Take(PageSize),
        //    PagingInfo = new PagingInfo //not working
        //    {
        //        CurrentPage = recipePage,
        //        RecipesPerPage = PageSize,
        //        TotalRecipes = repository.Recipes.Count()
        //    }
        //});




        [HttpGet]
        public IActionResult ReviewRecipe()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ViewRecipe(int id)
        {
            Recipe recipe = _repository.FindAllRecipes.Where(n => n.Id == id).FirstOrDefault();
            return View(recipe);
        }
    }
}