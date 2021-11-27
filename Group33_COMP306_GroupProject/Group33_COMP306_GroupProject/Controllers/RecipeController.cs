using AutoMapper;
using Group33_COMP306_GroupProject.DTOs;
using Group33_COMP306_GroupProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _recipeRepository.GetRecipes();
            var results = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipe(int id)
        {
            var recipe = await _recipeRepository.GetRecipe(id);
            var result = _mapper.Map<RecipeDto>(recipe);
            return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult<IEnumerable<Recipe>>> CreateRecipe(Recipe recipe)
        {
            var recipeNew = await _recipeRepository.CreateRecipe(recipe);
            var result = _mapper.Map<RecipeDto>(recipeNew);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> DeleteRecipe(int id)
        {
            await _recipeRepository.DeleteRecipe(id);
            return Ok();
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> UpdateRecipe(int id, Recipe recipe)
        {
            var recipeUpd = await _recipeRepository.UpdateRecipe(id, recipe);
            var result = _mapper.Map<RecipeDto>(recipeUpd);
            return Ok(result);
        }


    }
}
