using CorePub.AbstractionsProvider.CouchBase.Commons;
using Couchbase.Extensions.DependencyInjection;

namespace CorePub.AbstractionsProvider.CouchBase
{
    public interface IBucketService
    {
        INamedBucketProvider Get(BucketsCollection bucketName);
    }
}
