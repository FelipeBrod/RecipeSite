using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models.ViewModels
{
    public class Repository
    {

        private static readonly List<Recipe> recipes = new List<Recipe>();
        public static IEnumerable<Recipe> Recipes
        {
            get
            {
                return recipes;
            }
        }

        public static void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
      

    }
}

