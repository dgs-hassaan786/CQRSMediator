using CorePub.AbstractionsProvider.CouchBase.Commons;
using CorePub.AbstractionsProvider.CouchBase.IProviders;
using Couchbase.Extensions.DependencyInjection;
using System;

namespace CorePub.AbstractionsProvider.CouchBase
{
    public class BucketService : IBucketService
    {
        private IArticlesBucketProvider _articlesBucketProvider;

        public BucketService(IArticlesBucketProvider articlesBucketProvider)
        {
            _articlesBucketProvider = articlesBucketProvider;
        }

        public INamedBucketProvider Get(BucketsCollection bucketName)
        {
            switch (bucketName)
            {
                case BucketsCollection.articles:
                    return _articlesBucketProvider;
                default:
                    throw new NotImplementedException($"No bucket found of name {bucketName}");                    
            }
        }

        
    }
}
