using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
   public interface IRecipeRepository
    {        
      

        IQueryable<Recipe> GetRecipes();
        Recipe FindById(int id);

        Task UpdateAsync(Recipe obj);

        void SaveRecipe(Recipe recipe);

        Recipe DeleteRecipe(int id);
       
    }
}
