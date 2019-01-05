using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Common;
using MediatR;
using System;

namespace CorePub.Repositories.Articles.Commands
{
    public class CreateArticleCommand: IRequest //<CommandResult>
    {
        public CreateArticleCommandDto ArticleModel { get; private set; }

        public string Uid { get; }

        public CreateArticleCommand(CreateArticleCommandDto articleCommandDto)
        {
            Uid = Guid.NewGuid().ToString();
            ArticleModel = articleCommandDto;
        }
    }
}
