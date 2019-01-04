using CorePub.Repositories.Articles.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CorePub.Repositories.Articles.Queries
{
    public class GetArticlesByNameQuery : IRequest<List<ArticleDto>>
    {
        public string Name { get; private set; }

        public GetArticlesByNameQuery(string name)
        {
            Name = name;
        }
    }
}
