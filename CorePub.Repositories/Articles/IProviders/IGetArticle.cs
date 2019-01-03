using CorePub.Repositories.Articles.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.IProviders
{
    public interface IGetArticle
    {
        Task<List<ArticleDto>> GetAll();
        Task<List<ArticleDto>> GetByName(string name);
        Task<ArticleDto> GetById(long id);
        Task<ArticleDto> GetById(string uId);
    }
}
