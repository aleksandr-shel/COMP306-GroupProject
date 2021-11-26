using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.DTOs
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string IngredientAmount { get; set; }
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
