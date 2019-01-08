using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Models;
using CorePub.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Queries
{
    public class MockArticleService : IArticleService
    {
        private static List<Article> _articles = new List<Article>()
        {
            new Article()
            {
                Author = "Hassaan",
                Description = "First Article",
                Genre =  new [] { "Motivation" },
                Title = "How to motivate yourself?",                
                UId = Guid.NewGuid().ToString()
            },
            new Article()
            {
                Author = "Paul Cohleo",
                Description = "Eleven Minutes is a 2003 novel by Brazilian novelist Paulo Coelho that recounts the experiences of a young Brazilian prostitute and her journey to self-realisation through sexual experience.",
                Genre =  new [] { "Motivational", "Love", "Enthusiasm", "self-realisation" },
                Title = "Eleven Minutes",                
                UId = Guid.NewGuid().ToString()
            }
        };


        public Task<List<ArticleDto>> GetAll()
        {
            return Task.FromResult(_articles.Select(x => new ArticleDto()
            {
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId
            }).ToList());
        }

        public Task<ArticleDto> GetByUId(string uId)
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

        public Task<List<ArticleDto>> GetByTitle(string name)
        {
            return Task.FromResult(_articles.Where(x => x.Title.ToLowerInvariant().Contains(name.ToLowerInvariant())).Select(x => new ArticleDto()
            {
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId
            }).ToList());
        }

        public Task CreateArticle(CreateArticleCommandDto dto, string guid)
        {
            var articleAlreadyExistQuery = from a in _articles
                                           where a.Author.ToLowerInvariant() == dto.Author.ToLower() && a.Title.ToLowerInvariant() == dto.Title.ToLowerInvariant()
                                           select a;
            if (articleAlreadyExistQuery.SingleOrDefault() != null)
            {
                throw new AlreadyExistException($"Already exist an article");
            }
            else
            {
                var newArticle = new Article()
                {
                    Author = dto.Author,
                    Description = dto.Description,
                    Genre = dto.Genre.Split(',').Select(x=> x.Trim()).ToArray(),
                    Title = dto.Title,
                    UId = guid,                    
                };
                _articles.Add(newArticle);
            }
            return Task.FromResult(0);

        }

        public Task UpdateArticle(ArticleDto dto)
        {
            throw new NotImplementedException();
        }

        public Task RemoveArticle(string uid)
        {
            throw new NotImplementedException();
        }
    }
}
