using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models.ViewModels
{
    public class RecipesListViewModel
    {
        
        
        public IEnumerable<Recipe> Recipes { get; set; }
        public Recipe Recipe { get; set; }
        public Cuisine Cuisine { get; set; }
        public IEnumerable<Cuisine> Cuisines{ get; set; }
    }
}

