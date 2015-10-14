using System;

namespace Hydra.Core.Hashing
{
    /// <summary>
    /// Shard picker definition
    /// </summary>
    public interface ISharding
    {
        /// <summary>
        /// Get computed shard index
        /// </summary>
        /// <param name="key">Sharded identifier</param>
        /// <param name="buckets">Total number of shards</param>
        /// <returns>Index of a shard that is tied to the key</returns>
        Int32 GetShard(String key, Int32 buckets);
    }
}
