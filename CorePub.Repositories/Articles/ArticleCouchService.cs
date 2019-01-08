using CorePub.AbstractionsProvider.CouchBase;
using CorePub.AbstractionsProvider.CouchBase.Commons;
using CorePub.Repositories.Articles.Dtos;
using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Models;
using CorePub.Repositories.Common;
using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Repositories.Articles.Queries
{
    public class ArticleCouchService : IArticleService
    {
        private IBucketService _bucketService;
        private IBucket _bucket;

        public ArticleCouchService(IBucketService bucketService)
        {
            _bucketService = bucketService;
            _bucket = _bucketService.Get(AbstractionsProvider.CouchBase.Commons.BucketsCollection.articles).GetBucket();
        }

        public async Task<List<ArticleDto>> GetAll()
        {
            var query = $"SELECT uId as UId, title as Title,author as Author, description as Description, genre as Genre From `{CouchBaseBuckets.Article_Bucket}`"; //
            var queryResult = await _bucket.QueryAsync<ArticleDto>(query);
            return queryResult.Rows;
        }

        public async Task<ArticleDto> GetById(long id)
        {
            var query = $"SELECT uId as UId, title as Title,author as Author, description as Description, genre as Genre From `{CouchBaseBuckets.Article_Bucket}` where Id = {id} "; //UId, Title, Author, Description, Genre
            var queryResult = await _bucket.QueryAsync<ArticleDto>(query);
            return queryResult.FirstOrDefault();
        }

        public async Task<ArticleDto> GetByUId(string uId)
        {
            var query = $"SELECT uId as UId, title as Title,author as Author, description as Description, genre as Genre From `{CouchBaseBuckets.Article_Bucket}` where UId = {uId} ";//UId, Title, Author, Description, Genre
            var queryResult = await _bucket.QueryAsync<ArticleDto>(query);
            return queryResult.FirstOrDefault();
        }

        public async Task<List<ArticleDto>> GetByTitle(string name)
        {
            var query = $"SELECT uId as UId, title as Title,author as Author, description as Description, genre as Genre From `{CouchBaseBuckets.Article_Bucket}` where Title Like '%{name}%' ";//UId, Title, Author, Description, Genre 
            var queryResult = await _bucket.QueryAsync<ArticleDto>(query);
            return queryResult.Rows;
        }

        public async Task CreateArticle(CreateArticleCommandDto dto, string guid)
        {

            var articleAlreadyExistQuery = new QueryRequest().Statement(
                $"Select uId as UId from `{CouchBaseBuckets.Article_Bucket}` where author = $1 and LOWER(title) = $2"
                ).AddPositionalParameter(dto.Author, dto.Title);

            var q1Result = await _bucket.QueryAsync<ArticleDto>(articleAlreadyExistQuery);
            if (q1Result.FirstOrDefault() != null)
            {
                throw new AlreadyExistException($"Already exist an article");
            }
            else
            {
                var newArticle = new Document<Article>
                {
                    Id = Guid.NewGuid().ToString(),
                    Content = new Article()
                    {
                        Author = dto.Author,
                        Description = dto.Description,
                        Genre = dto.Genre.Split(',').Select(x => x.Trim()).ToArray(),
                        Title = dto.Title,
                        UId = guid
                    }
                };


                var result = await _bucket.InsertAsync(newArticle);
                if (result.Status != Couchbase.IO.ResponseStatus.Success)
                    throw new Exception("There was an error", new Exception(JsonConvert.SerializeObject(result)));
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
