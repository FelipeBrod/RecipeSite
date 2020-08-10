using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class Review
    {
        public int RecipeIndex { get; set; }
        public int Id { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }

    }
}
