using AutoMapper;
using Group33_COMP306_GroupProject.DTOs;
using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //IQueryable<Ingredient> ingredients = null;
            CreateMap<Recipe, RecipeDto>().ForMember(d => d.Ingredients, opt => opt.MapFrom(s => s.Ingredients));
            //.ForMember(x => x.Ingredients, opt =>
            //        opt.MapFrom(src => src.Ingredients.Join(ingredients, a => a.RecipeId, ).ToList()));
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}
