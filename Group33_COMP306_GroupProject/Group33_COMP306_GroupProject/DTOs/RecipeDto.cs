using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeType { get; set; }
        public string Description { get; set; }
        public string ImageIrl { get; set; }
        public string AuthorId { get; set; }

        public virtual ICollection<IngredientDto> Ingredients { get; set; }
        = new List<IngredientDto>();
    }
}
