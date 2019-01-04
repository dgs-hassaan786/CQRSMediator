using CorePub.Repositories.Articles.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CorePub.Repositories.Articles.Queries
{
    public class GetAllArticlesQuery : IRequest<List<ArticleDto>>
    {
        public GetAllArticlesQuery()
        {

        }
    }
}
