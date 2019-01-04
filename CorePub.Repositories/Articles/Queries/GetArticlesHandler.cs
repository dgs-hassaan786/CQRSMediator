using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Articles.IProviders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Queries
{
    public class GetArticlesHandler : IRequestHandler<GetAllArticlesQuery, List<ArticleDto>>
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
    }
}
