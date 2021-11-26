using Microsoft.EntityFrameworkCore;
using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Services
{
    public class IngredientRepository : IIngredientRepository
    {
        private COMP306_GroupProjectContext _context;

        public IngredientRepository(COMP306_GroupProjectContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ingredient>> GetIngredients(int id)
        {
            return await _context.Ingredients.Where(x => x.Id == id).ToListAsync();
        }
    }
}
