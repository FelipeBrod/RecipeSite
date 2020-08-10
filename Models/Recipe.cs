using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RecipeSite.Models.Enums;

namespace RecipeSite.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the recipe name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the cuisine")]
        public Cuisine Cuisine { get; set; }

        [Required(ErrorMessage = "Please enter the Instructions")]
        public string Preparation { get; set; }

        [Required(ErrorMessage = "Please enter the recipe ingredients")]
        public string Ingredients { get; set; }


        
    }
}
