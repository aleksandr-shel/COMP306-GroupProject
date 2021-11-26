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
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }
    }
}
