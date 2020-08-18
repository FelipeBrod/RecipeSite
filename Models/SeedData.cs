using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading;

namespace RecipeSite.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {


            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();



            if (context.Recipes.Any() || context.Cuisines.Any())
            {
                return;
            }

            Cuisine Br = new Cuisine(1, "Brazilian");
            Cuisine Cn = new Cuisine(2, "Chinese");
            Cuisine Cd = new Cuisine(3, "Canadian");

            context.Cuisines.AddRange(Br, Cn, Cd);

            context.Recipes.AddRange(
                new Recipe
                {
                    Name = "FriedEgg",
                    Ingredients = "Egg, Salt, Butter",
                    Cuisine = Br,
                    Preparation = "fry it",
                },
                new Recipe
                {
                    Name = "Scrambled Egg",
                    Ingredients = "Eggs, Salt, Butter",
                    Cuisine = Cn,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg",
                },
                new Recipe
                {
                    Name = "Boilded Egss",
                    Ingredients = "Egg",
                    Cuisine = Cd,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
                },
                
            new Recipe
            {
                Name = "Boilded Egss",
                Ingredients = "Egg",
                Cuisine = Br,
                Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
            });
            //new Recipe
            //{
            //    Name = "Boilded Egss",
            //    Ingredients = "Egg",
            //    Cuisine = br,
            //    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
            //},
            //new Recipe
            //{
            //    Name = "Boilded Egss",
            //    Ingredients = "Egg",
            //    Cuisine = br,
            //    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
            //});

            context.SaveChanges();

        }
    }
}


