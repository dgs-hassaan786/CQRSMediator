using CorePub.Repositories.Articles.Dtos;
using MediatR;

namespace CorePub.Repositories.Articles.Queries
{
    public class GetArticleByIdQuery : IRequest<ArticleDto>
    {
        public long Id { get; private set; }

        public GetArticleByIdQuery(long id)
        {
            Id = id;
        }
    }
}
