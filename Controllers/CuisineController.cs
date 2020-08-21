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
        private readonly ICuisineRepository CuisineRepository;


        public CuisineController(IRecipeRepository repo, ICuisineRepository cuRepo)
        {
            repository = repo;
            CuisineRepository = cuRepo;
        }

        [HttpPost]
        public IActionResult AddCuisine(Cuisine cuisine)
        {
            var cuisines = CuisineRepository.FindAll();
            var viewModel = new RecipesListViewModel { Cuisines = cuisines };

           

            if (ModelState.IsValid)
            {

                if (!CuisineRepository.GetCuisinesByName(cuisine.Name))
                {
                    CuisineRepository.SaveCuisine(cuisine);
                    return RedirectToAction("AddRecipe", "CRUD");
                }
            }
            return View("Views/CRUD/AddRecipe.cshtml", viewModel);
        }


        public IActionResult CuisineList(int id)
        {
            var list = new RecipesListViewModel
            {
                Recipes = repository.GetRecipes().Where(r => r.CuisineId == id),
                Cuisine = CuisineRepository.FindById(id)
            };

            return View(list);

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


        public ViewResult SearchByCuisine(string search)
        {
            RecipesListViewModel list = new RecipesListViewModel
            {
                Recipes = repository.GetRecipes()
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
