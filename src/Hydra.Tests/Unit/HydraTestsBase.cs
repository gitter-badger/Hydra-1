using System;
using Hydra.Core.Hashing;
using Microsoft.WindowsAzure.Storage;
using Moq;

namespace Hydra.Tests.Unit
{
    public abstract class HydraTestsBase
    {
        public static Core.IHydra Subject { get; private set; }

        static HydraTestsBase()
        {
            Subject = CreateHydra();
        }

        static Core.IHydra CreateHydra()
        {
            var sharding = new Mock<ISharding>();
            sharding.Setup(x => x.GetShard(It.IsAny<String>(), It.IsAny<Int32>()))
                .Returns(0);

            return Core.Hydra.Create(sharding.Object, new[] { CloudStorageAccount.DevelopmentStorageAccount });
        }
    }
}