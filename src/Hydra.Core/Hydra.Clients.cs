using System;
using Microsoft.WindowsAzure.Storage.Analytics;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace Hydra.Core
{
    public partial class Hydra : IHydra
    {
        public CloudTableClient CreateTableClient(String shardingKey)
        {
            return PickShard(shardingKey).CreateCloudTableClient();
        }

        public CloudBlobClient CreateBlobClient(String shardingKey)
        {
            return PickShard(shardingKey).CreateCloudBlobClient();
        }

        public CloudQueueClient CreateQueueClient(String shardingKey)
        {
            return PickShard(shardingKey).CreateCloudQueueClient();
        }

        public CloudAnalyticsClient CreateAnalyticsClient(String shardingKey)
        {
            return PickShard(shardingKey).CreateCloudAnalyticsClient();
        }

        public CloudFileClient CreateFileClient(String shardingKey)
        {
            return PickShard(shardingKey).CreateCloudFileClient();
        }
    }
}
