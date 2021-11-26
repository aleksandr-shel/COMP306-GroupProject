using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Services
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();

        Task<Recipe> GetRecipe(int id);

        Task<Recipe> CreateRecipe(Recipe recipe);

        Task DeleteRecipe(int id);

        Task<Recipe> UpdateRecipe(int id, Recipe recipe);
    }
}
