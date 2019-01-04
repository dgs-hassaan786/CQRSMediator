﻿using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Models;
using CorePub.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Queries
{
    public class ArticleService : IArticleService
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
            },
            new Article()
            {
                Author = "Paul Cohleo",
                Description = "Eleven Minutes is a 2003 novel by Brazilian novelist Paulo Coelho that recounts the experiences of a young Brazilian prostitute and her journey to self-realisation through sexual experience.",
                Genre =  new [] { "Motivational", "Love", "Enthusiasm", "self-realisation" },
                Title = "Eleven Minutes",
                Id = 2,
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

        public Task<ArticleDto> GetById(long id)
        {
            return Task.FromResult(_articles.Where(x => x.Id == id).Select(x => new ArticleDto()
            {
                Author = x.Author,
                Description = x.Description,
                Genre = x.Genre,
                Title = x.Title,
                UId = x.UId
            }).FirstOrDefault());
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

        public Task<List<ArticleDto>> GetByName(string name)
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

        public Task<string> CreateArticle(CreateArticleCommandDto dto)
        {
            var articleAlreadyExistQuery = from a in _articles
                                           where a.Author.ToLowerInvariant() == dto.Author.ToLower() && a.Title.ToLowerInvariant() == dto.Title.ToLowerInvariant()
                                           select a;
            if(articleAlreadyExistQuery.FirstOrDefault() != null)
            {
                throw new AlreadyExistException($"Already exist an article");
            }
            else
            {
                var newArticle = new Article()
                {
                    Author = dto.Author,
                    Description = dto.Author,
                    Genre = dto.Genre.Split(','),
                    Title = dto.Title,
                    UId = Guid.NewGuid().ToString(),
                    Id = _articles.Count + 1
                };
                _articles.Add(newArticle);

                return Task.FromResult(newArticle.UId);
            }

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
