using Microsoft.EntityFrameworkCore;
using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private COMP306_GroupProjectContext _context;

        public RecipeRepository(COMP306_GroupProjectContext context)
        {
            _context = context;
        }

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            var res = await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteRecipe(int id)
        {
            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            foreach(var ing in _context.Ingredients)
            {
                if (ing.Recipe == recipe)
                {
                    _context.Ingredients.Remove(ing);
                }
            }
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            return await _context.Recipes.Include(c=>c.Ingredients).ThenInclude(c=>c.Recipe).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _context.Recipes.Include(c => c.Ingredients).ThenInclude(c=>c.Recipe).ToListAsync();
        }

        public async Task<Recipe> UpdateRecipe(int id, Recipe recipe)
        {
            Recipe recipeToUpd = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            recipeToUpd.RecipeName = recipe.RecipeName;
            recipeToUpd.RecipeType = recipe.RecipeType;
            recipeToUpd.ImageIrl = recipe.ImageIrl;
            await _context.SaveChangesAsync();
            return await _context.Recipes.Include(c => c.Ingredients).ThenInclude(c => c.Recipe).FirstOrDefaultAsync(x => x.Id == id); ;
        }
    }
}
