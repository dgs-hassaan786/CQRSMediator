using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Common;
using MediatR;

namespace CorePub.Repositories.Articles.Commands
{
    public class CreateArticleCommand: IRequest<CommandResult>
    {
        public CreateArticleCommandDto ArticleModel { get; private set; }

        public CreateArticleCommand(CreateArticleCommandDto articleCommandDto)
        {
            ArticleModel = articleCommandDto;
        }
    }
}
