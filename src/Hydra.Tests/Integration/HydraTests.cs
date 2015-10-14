using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Xunit;

namespace Hydra.Tests.Integration
{
    public class HydraTests : IntegrationBase
    {
        const Int32 UserCount = 10000;

        [Fact]
        public void CreatesFiveTableClients()
        {
            var clients = new HashSet<CloudTableClient>();

            for (int i = 0; i < UserCount; i++)
            {
                clients.Add(Subject.CreateTableClient(Guid.NewGuid().ToString()));
            }

            Assert.Equal(5, clients.Count);
        }

        [Fact]
        public void CreatesFiveBlobClients()
        {
            var clients = new HashSet<CloudBlobClient>();

            for (int i = 0; i < UserCount; i++)
            {
                clients.Add(Subject.CreateBlobClient(Guid.NewGuid().ToString()));
            }

            Assert.Equal(5, clients.Count);
        }

        [Fact]
        public void CreatesFiveQueueClients()
        {
            var clients = new HashSet<CloudQueueClient>();

            for (int i = 0; i < UserCount; i++)
            {
                clients.Add(Subject.CreateQueueClient(Guid.NewGuid().ToString()));
            }

            Assert.Equal(5, clients.Count);
        }
    }
}
