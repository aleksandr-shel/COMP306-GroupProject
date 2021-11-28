using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWebApp.Controllers
{
    public class IngredientController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "http://group33comp306groupproject-dev.ca-central-1.elasticbeanstalk.com/";
        //string uri = "https://localhost:5001/";
        HttpResponseMessage response;

        public IngredientController()
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientForRecipe(string ingredientName, string ingredientAmount, int recipeId)
        {
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = ingredientName,
                IngredientAmount = ingredientAmount
            };

            var json = JsonConvert.SerializeObject(ingredient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync($"api/Ingredient/{recipeId}/ingredients", content);

            //response = await client.PostAsJsonAsync($"{recipeId}/ingredients", ingredient);

            return RedirectToAction(nameof(Index), nameof(Recipe));
        }

        public ActionResult Create(int recipeId)
        {
            return View("IngredientInfo", new IngredientCreateViewModel() { IngredientEntity = null, RecipeId = recipeId });
        }

        [HttpPost]
        public async Task<IActionResult> Update(string ingredientName, string ingredientAmount, int recipeId, int ingredientId)
        {
            string json;
            try
            {   
                response = await client.GetAsync($"api/Ingredient/{recipeId}/ingredients/{ingredientId}");
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    Ingredient ingredient = JsonConvert.DeserializeObject<Ingredient>(json);

                    //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    ingredient.IngredientName = ingredientName;
                    ingredient.IngredientAmount = ingredientAmount;
                    response = await client.PutAsJsonAsync($"api/Ingredient/{recipeId}/ingredients/{ingredientId}", ingredient);
                }
                else
                {
                    Console.WriteLine("Internal Server error");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction(nameof(Index), nameof(Recipe));
        }

        public async Task<ActionResult> UpdateIngredientPage(int recipeId, int ingredientId)
        {
            Ingredient ingredient = new();

            response = await client.GetAsync($"api/Ingredient/{recipeId}/ingredients/{ingredientId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                ingredient = JsonConvert.DeserializeObject<Ingredient>(json);
            }

            return View("IngredientUpdatePage", new IngredientCreateViewModel() { IngredientEntity = ingredient, RecipeId = recipeId });
        }

        public async Task<ActionResult> Delete(int recipeId, int ingredientId)
        {
            try
            {
                response = await client.DeleteAsync($"api/Ingredient/{recipeId}/ingredients/{ingredientId}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction(nameof(Index), nameof(Recipe));
        }
    }
}