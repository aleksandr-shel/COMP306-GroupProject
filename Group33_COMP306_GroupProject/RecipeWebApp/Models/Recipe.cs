using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeType { get; set; }
        public string Description { get; set; }
        public string ImageIrl { get; set; }
        public string AuthorId { get; set; }
        public Ingredient[] Ingredients { get; set; }

        
    }
}
