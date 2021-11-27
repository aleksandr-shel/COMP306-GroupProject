using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Services
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredients();

        Task<Ingredient> GetIngredient(int id);

        Task<Ingredient> CreateIngredient(Ingredient ingredient);

        Task DeleteIngredient(int id);

        Task<Ingredient> UpdateIngredient(int id, Ingredient ingredient);

        Task<IEnumerable<Ingredient>> GetIngredientsForRecipe(int recipeId);

        Task<Ingredient> GetIngredientsForRecipe(int recipeId, int ingredientId);

        Task AddIngredientsForRecipe(int recipeId, Ingredient ingredient);

        Task<bool> Save();
    }
}
