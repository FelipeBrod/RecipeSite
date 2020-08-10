using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeSite.Models.Enums;

namespace RecipeSite.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                new Recipe
                {
                    Name = "FriedEgg",
                    Ingredients = "Egg, Salt, Butter",
                    Cuisine = (Cuisine)1,
                    Preparation = "fry it",
                },
                new Recipe
                {
                    Name = "Scrambled Egg",
                    Ingredients = "Eggs, Salt, Butter",
                    Cuisine = (Cuisine)2,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg",
                },
                new Recipe
                {
                    Name = "Boilded Egss",
                    Ingredients = "Egg",
                    Cuisine = (Cuisine)3,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
                },
                new Recipe
                {
                    Name = "Boilded Egss",
                    Ingredients = "Egg",
                    Cuisine = (Cuisine)5,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
                },
                new Recipe
                {
                    Name = "Boilded Egss",
                    Ingredients = "Egg",
                    Cuisine = (Cuisine)6,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
                },
                new Recipe
                {
                    Name = "Boilded Egss",
                    Ingredients = "Egg",
                    Cuisine = (Cuisine)2,
                    Preparation = "Put the butter on the pan, wait for it to melt and than put the egg and salt."
                }
                        ) ;
                context.SaveChanges();
            }
        }
    }
}

