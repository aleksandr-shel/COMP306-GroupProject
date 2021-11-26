using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Services
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredients(int id);
    }
}
