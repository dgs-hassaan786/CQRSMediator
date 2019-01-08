using CorePub.Repositories.Articles.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CorePub.Repositories.Articles.IProviders
{
    public interface IArticleService 
    {
        Task<List<ArticleDto>> GetAll();
        Task<List<ArticleDto>> GetByTitle(string name);        
        Task<ArticleDto> GetByUId(string uId);

        Task CreateArticle(CreateArticleCommandDto dto, string guid);
        Task UpdateArticle(ArticleDto dto);
        Task RemoveArticle(string uid);
    }
}
