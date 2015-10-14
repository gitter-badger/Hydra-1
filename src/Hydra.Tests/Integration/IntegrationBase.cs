﻿using System;
using Hydra.Core;
using Hydra.Core.Sharding;
using Microsoft.WindowsAzure.Storage;

namespace Hydra.Tests.Integration
{
    public abstract class IntegrationBase
    {
        public const String TableName = "testtable";
        public const String ContainerName = "testcontainer";
        public const String QueueName = "testqueue";

        public static String TestKey = Guid.NewGuid().ToString();

        public static IHydra Subject { get; private set; }

        static IntegrationBase()
        {
            //PrepareAccount(CloudStorageAccount.DevelopmentStorageAccount);

            Subject = CreateHydra();
        }

        static void PrepareAccount(CloudStorageAccount account)
        {
            var table = account.CreateCloudTableClient();
            var tableRef = table.GetTableReference(TableName);
            tableRef.CreateIfNotExists();

            var blob = account.CreateCloudBlobClient();
            var blobRef = blob.GetContainerReference(ContainerName);
            blobRef.CreateIfNotExists();

            var queue = account.CreateCloudQueueClient();
            var queueRef = queue.GetQueueReference(QueueName);
            queueRef.CreateIfNotExists();
        }

        static IHydra CreateHydra()
        {
            var sharding = new JumpSharding();

            return Core.Hydra.Create(sharding, new[] { CloudStorageAccount.DevelopmentStorageAccount,
                                                       CloudStorageAccount.DevelopmentStorageAccount,
                                                       CloudStorageAccount.DevelopmentStorageAccount,
                                                       CloudStorageAccount.DevelopmentStorageAccount,
                                                       CloudStorageAccount.DevelopmentStorageAccount });
        }
    }
}
