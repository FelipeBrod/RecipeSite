using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
   public interface IRecipeRepository
    {        
       List<Recipe> FindAllRecipes { get; }

        Recipe FindById(int id);

        void SaveRecipe(Recipe recipe);

        Recipe DeleteRecipe(int id);

    }
}
