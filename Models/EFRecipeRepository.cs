using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        List<Recipe> IRecipeRepository.FindAllRecipes => context.Recipes.ToList();

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public Recipe FindById(int id)
        {
            return context.Recipes.Include(obj => obj.Cuisine).FirstOrDefault(obj => obj.Id == id);
        }


        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.Id == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe dbEntry = context.Recipes
                .FirstOrDefault(p => p.Id == recipe.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = recipe.Name;
                    dbEntry.Ingredients = recipe.Ingredients;
                    dbEntry.Preparation = recipe.Preparation;
                    dbEntry.Cuisine = recipe.Cuisine;
                   
                }
            }
            context.SaveChanges();
        }
        public Recipe DeleteRecipe(int id)
        {
           // EFRecipeRepository eFRecipeRepository = new EFRecipeRepository(context);

           //eFRecipeRepository.DeleteRecipe(id);

            Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }
    } 


}
