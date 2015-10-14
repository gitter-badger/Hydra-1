using System;
using System.Collections.Concurrent;
using Hydra.Core.Sharding;
using Microsoft.WindowsAzure.Storage;

namespace Hydra.Core
{
    public class StorageFactory<T>
    {
        readonly Func<CloudStorageAccount, T> _createFunc;
        readonly ConcurrentDictionary<Int32, T> _items = new ConcurrentDictionary<Int32, T>();

        public StorageFactory(Func<CloudStorageAccount, T> createFunc)
        {
            _createFunc = createFunc;
        }

        public T Create(Shard shard)
        {
            T result;

            if (_items.TryGetValue(shard.Index, out result))
            {
                return result;
            }

            result = _createFunc(shard.Account);

            _items.AddOrUpdate(shard.Index, result, (i, arg2) => result);

            return result;
        }
    }
}