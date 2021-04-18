using Newtonsoft.Json;
using RecipeCodeSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecipeCodeSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(HomeViewModel postModel)
        {
            if(ModelState.IsValid)
            {
                var recipes = new RecipeResponseModel();
                
                if(postModel.Ingredients != null && postModel.Ingredients.Count > 0)
                {
                    var ingredientList = string.Join(",", postModel.Ingredients.Select(i => i.Label));

                    recipes = await PullRecipes(ingredientList);
                }

                return PartialView("_Recipes", recipes);
            }

            return View(postModel);
        }

        public async Task<RecipeResponseModel> PullRecipes(string ingredients)
        {
            var responseModel = new RecipeResponseModel();

            string url = "http://www.recipepuppy.com/api/?i=" + ingredients;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<RecipeResponseModel>(content);
            }

            return responseModel;
        }

        public PartialViewResult AddIngredient(string ingredient)
        {
            return PartialView("_Ingredient", new Ingredient { Label = ingredient });
        }
    }
}