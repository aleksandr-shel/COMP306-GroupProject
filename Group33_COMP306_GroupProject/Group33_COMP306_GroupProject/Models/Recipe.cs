using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group33_COMP306_GroupProject.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        
        [NotMapped]
        public List<string> Ingredients { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string imageUrl { get; set; }

        public string authorId { get; set; }
    }
}