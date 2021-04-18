using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCodeSample.Models
{
    public class RecipeResponseModel
    {
        public RecipeResponseModel()
        {
            Results = new List<RecipeItem>();
        }

        public List<RecipeItem> Results { get; set; }
    }

    public class RecipeItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("href")]
        public string Link { get; set; }

        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}