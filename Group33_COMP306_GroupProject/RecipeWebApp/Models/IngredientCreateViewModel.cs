using System;

namespace RecipeWebApp.Models
{
    public class IngredientCreateViewModel
    {
        public Ingredient IngredientEntity { get; set; }
        public int RecipeId { get; set; }
    }
}