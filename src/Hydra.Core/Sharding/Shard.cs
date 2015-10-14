using System;
using Microsoft.WindowsAzure.Storage;

namespace Hydra.Core.Sharding
{
    public class Shard
    {
        public Int32 Index { get; set; }
        public CloudStorageAccount Account { get; set; }
    }
}