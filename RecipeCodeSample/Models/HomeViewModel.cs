using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeCodeSample.Models
{
    public class HomeViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string Label { get; set; }
    }
}