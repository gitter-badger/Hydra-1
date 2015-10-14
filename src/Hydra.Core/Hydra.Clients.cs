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
        readonly StorageFactory<CloudTableClient> _tableClients = new StorageFactory<CloudTableClient>(x => x.CreateCloudTableClient());
        readonly StorageFactory<CloudBlobClient> _blobClients = new StorageFactory<CloudBlobClient>(x => x.CreateCloudBlobClient());
        readonly StorageFactory<CloudQueueClient> _queueClients = new StorageFactory<CloudQueueClient>(x => x.CreateCloudQueueClient());
        readonly StorageFactory<CloudAnalyticsClient> _analyticsClients = new StorageFactory<CloudAnalyticsClient>(x => x.CreateCloudAnalyticsClient());
        readonly StorageFactory<CloudFileClient> _fileClients = new StorageFactory<CloudFileClient>(x => x.CreateCloudFileClient());

        public CloudTableClient CreateTableClient(String shardingKey)
        {
            return _tableClients.Create(PickShard(shardingKey));
        }

        public CloudBlobClient CreateBlobClient(String shardingKey)
        {
            return _blobClients.Create(PickShard(shardingKey));
        }

        public CloudQueueClient CreateQueueClient(String shardingKey)
        {
            return _queueClients.Create(PickShard(shardingKey));
        }

        public CloudAnalyticsClient CreateAnalyticsClient(String shardingKey)
        {
            return _analyticsClients.Create(PickShard(shardingKey));
        }

        public CloudFileClient CreateFileClient(String shardingKey)
        {
            return _fileClients.Create(PickShard(shardingKey));
        }
    }
}
