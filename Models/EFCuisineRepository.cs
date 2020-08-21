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
        public Cuisine FindById(int id)
        {
            return context.Cuisines.FirstOrDefault(obj => obj.Id == id);
        }

        public List<Cuisine> FindAll() => context.Cuisines.OrderBy(x => x.Name).ToList();

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

        public IQueryable<Cuisine> GetCuisines()
        {
            return context.Cuisines;
        }
        
        public bool GetCuisinesByName(string name)
        {

            Cuisine newCuisine = context.Cuisines.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if(newCuisine != null)
            {
                return true;
            }

            return false;
        }
    }
}
