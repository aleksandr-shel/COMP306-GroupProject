﻿using Microsoft.EntityFrameworkCore;
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
        private IRecipeRepository _recipeRepository;

        public IngredientRepository(COMP306_GroupProjectContext context, IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
            _context = context;
        }

        public async Task<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            var ing = await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
            return ing.Entity;
        }

        public async Task DeleteIngredient(int id)
        {
            Ingredient ingredient = await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
            foreach (var res in _context.Recipes)
            {
                if (res.Ingredients == ingredient)
                {
                    _context.Recipes.Remove(res);
                }
            }
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<Ingredient> GetIngredient(int id)
        {
            return await _context.Ingredients.Include(c => c.Recipe).ThenInclude(c => c.Ingredients).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            return await _context.Ingredients.Include(c => c.Recipe).ThenInclude(c => c.Ingredients).ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsForRecipe(int recipeId)
        {
            IQueryable<Ingredient> result = _context.Ingredients.Where(p => p.RecipeId == recipeId);
            return await result.ToListAsync();
        }

        public async Task<Ingredient> GetIngredientsForRecipe(int recipeId, int ingredientId)
        {
            IQueryable<Ingredient> result = _context.Ingredients.Where(p => p.RecipeId == recipeId && p.Id == ingredientId);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<Ingredient> UpdateIngredient(int id, Ingredient ingredient)
        {
            Ingredient ingredientToUpd = await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
            ingredientToUpd.IngredientName = ingredient.IngredientName;
            ingredientToUpd.IngredientAmount = ingredient.IngredientAmount;
            await _context.SaveChangesAsync();
            return await _context.Ingredients.Include(c => c.Recipe).ThenInclude(c => c.Ingredients).FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task AddIngredientsForRecipe(int recipeId, Ingredient ingredient)
        {
            var recipe = await _recipeRepository.GetRecipe(recipeId);
            recipe.Ingredients.Add(ingredient);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
