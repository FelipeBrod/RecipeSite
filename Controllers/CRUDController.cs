using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    public class CRUDController : Controller
    {
        private IRecipeRepository repository;


        public CRUDController(IRecipeRepository repo)
        {
            repository = repo;
        }

        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                return View("Success", recipe);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult AddRecipe() => View();

        [HttpGet]
        public ViewResult UpdateRecipe(int id)
        {
            Recipe recipe = repository.Recipes.Where(n => n.Id == id).FirstOrDefault();
           
            return View("AddRecipe", recipe);
        }

        [HttpPost]
        public IActionResult DeleteRecipe(int id)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(id);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted";
            }
            return RedirectToAction("RecipeList", "Recipes");
        }
    }
}
