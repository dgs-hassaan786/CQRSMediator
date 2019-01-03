namespace CorePub.Repositories.Articles.Models
{
    public class Article
    {
        public Article()
        {

        }
        
        public long Id { get; set; }
        public string UId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }        
        public string Description { get; set; }
        public string[] Genre { get; set; }
    }
}
