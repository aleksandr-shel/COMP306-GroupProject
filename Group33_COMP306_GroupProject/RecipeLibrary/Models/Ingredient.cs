using System;
using System.Collections.Generic;

#nullable disable

namespace RecipeLibrary.Models
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string IngredientAmount { get; set; }
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
