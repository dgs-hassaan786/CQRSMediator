using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Queries
{
    public class ArticleService :  IArticleService  //IRequestHandler<IArticleService,List<ArticleDto>>
    {
        private static List<Article> _articles = new List<Article>()
        {
            new Article()
            {
                Author = "Hassaan",
                Description = "First Article",
                Genre =  new [] { "Motivation" },
                Title = "How to motivate yourself?",
                Id = 1,
                UId = Guid.NewGuid().ToString()
            }
        };


        public Task<List<ArticleDto>> GetAll()
        {
            return Task.FromResult(_articles.Select(x=> new ArticleDto() {
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId
            }).ToList());
        }

        public Task<ArticleDto> GetById(long id)
        {
            return Task.FromResult(_articles.Where(x => x.Id == id).Select(x=> new ArticleDto() {            
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId            
            }).FirstOrDefault());
        }

        public Task<ArticleDto> GetById(string uId)
        {
            return Task.FromResult(_articles.Where(x => x.UId == uId).Select(x => new ArticleDto()
            {
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId
            }).FirstOrDefault());
        }

        public Task<List<ArticleDto>> GetByName(string name)
        {
            return Task.FromResult(_articles.Where(x => x.Title == name).Select(x => new ArticleDto()
            {
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId
            }).ToList());
        }        
    }
}
