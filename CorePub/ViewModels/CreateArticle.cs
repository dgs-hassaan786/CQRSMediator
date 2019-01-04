using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Common;

namespace CorePub.ViewModels
{
    public class CreateArticle
    {
        public CreateArticleCommandDto CreateArticleModel { get; set; } = new CreateArticleCommandDto();
        public CommandResult CommandResult { get; set; }

    }
}
