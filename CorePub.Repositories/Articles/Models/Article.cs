using Newtonsoft.Json;
using System;

namespace CorePub.Repositories.Articles.Models
{
    public class Article
    {
        public Article()
        {

        }

        [JsonProperty("uId")] 
        public string UId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("genre")]
        public string[] Genre { get; set; }
        [JsonProperty("created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [JsonProperty("modified")]
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    }
}
