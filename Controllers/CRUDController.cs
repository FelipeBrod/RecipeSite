using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private readonly IRecipeRepository repository;
        private readonly ICuisineRepository CuisineRepository;


        public CRUDController(IRecipeRepository repo, ICuisineRepository cuRepo)
        {
            repository = repo;
            CuisineRepository = cuRepo;
        }

        
        public IActionResult AddRecipe()
        {
            var cuisines = CuisineRepository.FindAll();
            var viewModel = new RecipesListViewModel { Cuisines = cuisines };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {

            if (!ModelState.IsValid)
            {
                var cuisines = CuisineRepository.FindAll();
                var viewModel = new RecipesListViewModel { Recipe = recipe, Cuisines = cuisines };
                return View(viewModel);
            }
            
            repository.SaveRecipe(recipe);
            return RedirectToAction("RecipeList", "Recipes");

        }

        [HttpGet]
         public IActionResult UpdateRecipe(int id)
        {

            var obj = repository.FindById(id);
            List<Cuisine> cuisines = CuisineRepository.FindAll();
            RecipesListViewModel viewModel = new RecipesListViewModel { Recipe = obj, Cuisines = cuisines};
            
            return View("/Views/CRUD/AddRecipe.cshtml", viewModel);
        }


        [HttpPost]
        public IActionResult DeleteRecipe(Recipe recipe)
        {
            Recipe deletedRecipe = repository.FindById(recipe.Id);

            if (deletedRecipe != null)
            {
                repository.DeleteRecipe(deletedRecipe.Id);
                TempData["message"] = $"{deletedRecipe.Name} was deleted";
                return RedirectToAction("RecipeList", "Recipes");
            }
            else
            {
                return RedirectToAction("RecipeList", "Recipes");
            }
        }
    }
}
