namespace CorePub.Repositories.Articles.Dtos
{
    public class ArticleDto
    {
        public string UId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string[] Genre { get; set; }        
    }
}
