using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public interface ICuisineRepository
    {

        IQueryable<Cuisine> GetCuisines(); 

        void SaveCuisine(Cuisine cuisine);

        Cuisine DeleteCuisine(int id);
        List<Cuisine> FindAll();

        Cuisine FindById(int id);

        bool GetCuisinesByName(string name);
    }
}
