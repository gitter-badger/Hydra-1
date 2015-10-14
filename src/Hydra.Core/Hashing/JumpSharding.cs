using System;
using System.Text;
using Murmur;

namespace Hydra.Core.Hashing
{
    /// <summary>
    /// Jump Consistent Hash implementation for shard picker
    /// </summary>
    public class JumpSharding : ISharding
    {
        /// <summary>
        /// Get computed shard index
        /// </summary>
        /// <param name="key">Sharded identifier</param>
        /// <param name="buckets">Total number of shards</param>
        /// <returns>Index of a shard that is tied to the key</returns>
        public Int32 GetShard(String key, Int32 buckets)
        {
            var murmur128 = MurmurHash.Create32(managed: false);

            var data = murmur128.ComputeHash(Encoding.ASCII.GetBytes(key));

            return JumpConsistentHash(BitConverter.ToUInt32(data, 0), buckets);
        }

        static Int32 JumpConsistentHash(UInt64 key, Int32 buckets)
        {
            Int64 b = 1;
            Int64 j = 0;

            while (j < buckets)
            {
                b = j;
                key = key * 2862933555777941757 + 1;

                var x = (Double)(b + 1);
                var y = (Double)(((Int64)(1)) << 31);
                var z = (Double)((key >> 33) + 1);

                j = (Int64)(x * (y / z));
            }

            return (Int32)b;
        }
    }
}
