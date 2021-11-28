using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWebApp.Controllers
{
    public class IngredientController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:5001/";
        HttpResponseMessage response;

        public IngredientController()
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpPost("{recipeId}/ingredients/AddIngredient")]
        [ValidateAntiForgeryToken]
        public async void AddIngredientForRecipe(Ingredient ingredient, int recipeId)
        {
            var json = JsonConvert.SerializeObject(ingredient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync($"{recipeId}/ingredients", content);

            response = await client.PostAsJsonAsync($"{recipeId}/ingredients", ingredient);

            Console.WriteLine($"status from POST {response.StatusCode}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"added resource at {response.Headers.Location}");

            json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Ingredient has been inserted" + json);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            return View("IngredientInfo", new IngredientCreateViewModel() { IngredientEntity = null, RecipeId = id });
        }
    }
}