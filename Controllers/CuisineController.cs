using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models.ViewModels;
using RecipeSite.Models;

namespace RecipeSite.Controllers
{
    public class CuisineController : Controller
    {
        private readonly IRecipeRepository repository;

        public CuisineController(IRecipeRepository repo)
        {
             repository = repo;
        }

        public ViewResult SearchByCuisine(string search)
        {
            RecipesListViewModel list = new RecipesListViewModel
            {
                Recipes = repository.FindAllRecipes
                          .Where(p => p.Cuisine.Name.Contains(search))
            };
            if (list.Recipes.Count() == 0)
            {
                ViewBag.Message = "No recipes found in the selected cusine!";
            }

            return View("/Views/Recipe/RecipeList.cshtml", list);
        }

    }

    
}
