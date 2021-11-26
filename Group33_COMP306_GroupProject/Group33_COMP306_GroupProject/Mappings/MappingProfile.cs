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
            CreateMap<Recipe, RecipeDto>();
                //.ForMember(dto => dto.Ingredients, opt => opt.MapFrom(model => model.Ingredients))
                //.AfterMap((model, dto) =>
                //{
                //    foreach (var dtoIngr in dto.Ingredients)
                //    {
                //        dtoIngr.Recipe = dto;
                //    }
                //});
            CreateMap<Ingredient, IngredientDto>();


        }
    }
}
