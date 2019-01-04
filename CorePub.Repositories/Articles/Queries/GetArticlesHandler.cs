using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Articles.IProviders;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Queries
{
    public class GetArticlesHandler : 
        IRequestHandler<GetAllArticlesQuery, List<ArticleDto>>,
        IRequestHandler<GetArticleByIdQuery,ArticleDto>,
        IRequestHandler<GetArticlesByNameQuery, List<ArticleDto>>,
        IRequestHandler<GetArticleByUIdQuery,ArticleDto>
    {
        private IArticleService _articleService;
      
        public GetArticlesHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<List<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _articleService.GetAll();
        }

        public async Task<ArticleDto> Handle(GetArticleByUIdQuery request, CancellationToken cancellationToken)
        {
            return await _articleService.GetByUId(request.UId);
        }

        public async Task<List<ArticleDto>> Handle(GetArticlesByNameQuery request, CancellationToken cancellationToken)
        {
            return await _articleService.GetByName(request.Name);
        }

        public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _articleService.GetById(request.Id);
        }
    }
}
