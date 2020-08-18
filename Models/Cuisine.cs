using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class Cuisine
    {
        
        public int Index { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public Cuisine()
        {

        }

        public Cuisine(int id, string name)
        {
            Index = id;
            Name = name;
        }
        public void AddRecipe(Recipe recipe)
        {
           Recipes.Add(recipe);
         }


    }
}
