using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Group33_COMP306_GroupProject.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}