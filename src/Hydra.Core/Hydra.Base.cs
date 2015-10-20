using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Hydra.Core.Sharding;
using Microsoft.WindowsAzure.Storage;

namespace Hydra.Core
{
    public partial class Hydra : IHydra
    {
        readonly ConcurrentBag<CloudStorageAccount> _accounts = new ConcurrentBag<CloudStorageAccount>();

        ISharding _sharding;

        public IEnumerable<CloudStorageAccount> Accounts => _accounts;

        public ISharding Sharding => _sharding;

        public IHydra AddAccount(CloudStorageAccount account)
        {
            _accounts.Add(account);
            return this;
        }

        public IHydra SetSharding(ISharding sharding)
        {
            _sharding = sharding;
            return this;
        }

        public static IHydra Create()
        {
            return new Hydra();
        }

        public static IHydra Create(ISharding sharding)
        {
            return new Hydra().SetSharding(sharding);
        }

        public static IHydra Create(ISharding sharding, IEnumerable<CloudStorageAccount> accounts)
        {
            var hydra = new Hydra().SetSharding(sharding);

            foreach (var account in accounts)
            {
                hydra.AddAccount(account);
            }

            return hydra;
        }

        public static IHydra Create(ISharding sharding, params CloudStorageAccount[] accounts)
        {
            return Create(sharding, accounts);
        }

        Shard PickShard(String shardingKey)
        {
            var shard = _sharding.GetShard(shardingKey, Accounts.Count());
            var account = Accounts.ElementAt(shard);

            return new Shard()
            {
                Index = shard,
                Account = account
            };
        }
    }
}
