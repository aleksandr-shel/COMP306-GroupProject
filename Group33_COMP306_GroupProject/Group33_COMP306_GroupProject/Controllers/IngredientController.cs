using AutoMapper;
using Group33_COMP306_GroupProject.DTOs;
using Group33_COMP306_GroupProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group33_COMP306_GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientController(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredient(int id)
        {
            var ingredients = await _ingredientRepository.GetIngredients(id);
            var results = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            return Ok(results);
        }
    }
}
