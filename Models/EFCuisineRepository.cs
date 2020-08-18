using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeSite.Models;

namespace RecipeSite.Models
{
    public class EFCuisineRepository : ICuisineRepository
    {
        private ApplicationDbContext context;

        public EFCuisineRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }



        public IQueryable<Cuisine> Cuisines => context.Cuisines;

        public async Task<List<Cuisine>> FindAllAsync()
        {
            return await context.Cuisines.OrderBy(x => x.Name).ToListAsync();
        }

        public void SaveCuisine(Cuisine cuisine)
        {
            Cuisine newCuisine = new Cuisine();
            newCuisine.Name = cuisine.Name;

            context.Cuisines.Add(newCuisine);
            context.SaveChanges();
        }

        public Cuisine DeleteCuisine(int id)
        {
            Cuisine dbEntry = context.Cuisines.FirstOrDefault(c => c.Index == id);
            if (dbEntry != null)
            {
                context.Cuisines.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;

        }

    }
}
