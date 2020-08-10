using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class Ingredient
    {
        public double Quantity { get; set; }
        public string WeightOrVol { get; set; }
        public string Name { get; set; }


        //    public Ingredient()
        //    {

        //    }

        //    public Ingredient(double quantity, string weightOrVol, string name)
        //    {
        //        Quantity = quantity;
        //        WeightOrVol = weightOrVol;
        //        Name = name;

        //    }
        //}
    }
}
