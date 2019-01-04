namespace CorePub.Repositories.Articles.Dtos
{
    public class CreateArticleCommandDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
