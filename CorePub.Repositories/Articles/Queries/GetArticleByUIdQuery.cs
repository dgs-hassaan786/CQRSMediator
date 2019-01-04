using CorePub.Repositories.Articles.Dtos;
using MediatR;

namespace CorePub.Repositories.Articles.Queries
{
    public class GetArticleByUIdQuery : IRequest<ArticleDto>
    {
        public string UId { get; private set; }    

        public GetArticleByUIdQuery(string uId)
        {
            UId = uId; 
        }
    }
}
