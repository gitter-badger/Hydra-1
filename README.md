## Hydra

A set of components to take the most advantage of performance and capacity of Azure Storage.

## Hydra.Code

A central component for scaling across multiple Storage Accounts. It is using a ISharding strategy to compute consistent hashes that pick a right Storage Account by key provided.

Default implementation of ISharding provided is JummpSharding that implement's Jump Consistent Hash.

Hydra.Core doesn't manage shard migration, which means you are constrained the amount of Storage Accounts you start of with. The more the better.

Hydra.Core is Azure Subscribtion agnostic, which means it is possible to use Storage Accounts from different Azure Subscriptions.

The above functionality gives the developer configurable IOPS and Disk Space with no upper limits.

### Advanced usage

It is possible to have multiple instances of Hydra, configured to point at different and/or the same Storage Accounts, with different and/or the same ISharding implementations. That feature gives the developer maximum flexibility for making sure the right data is distributed in the right way.

### Example

Example usage can be found in the Hydra.Tests.Integration namespace.
