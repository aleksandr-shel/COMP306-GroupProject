using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [DisplayName("Recipe name")]
        public string RecipeName { get; set; }
        [DisplayName("Recipe type")]
        public string RecipeType { get; set; }

        public string Description { get; set; }

        [DisplayName("Image")]
        public string ImageIrl { get; set; }

        [DisplayName("Author")]
        public string AuthorId { get; set; }

        [DisplayName("Ingredients")]
        public List<Ingredient> Ingredients { get; set; }

        
    }
}
