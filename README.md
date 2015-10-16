## Hydra

A set of components to take the most advantage of performance and capacity of Azure Storage. 

Hydra is Azure Subscribtion agnostic, which means it is possible to use Storage Accounts from different Azure Subscriptions. This functionality gives the developer configurable IOPS and Disk Space with no upper limits.

## Overview

![Link](https://github.com/Mailcloud/Hydra/blob/master/doc/architecture.png)

## Hydra.Core

` class Hydra : IHydra `

A central component for scaling across multiple Storage Accounts. It is using a ISharding strategy to compute consistent hashes that pick a right Storage Account by key provided.

` class JumpSharding : ISharding `

Default implementation of ISharding provided is JumpSharding that implement's Jump Consistent Hash.

### Disclaimer

Hydra.Core doesn't manage shard migration, which means you are constrained the amount of Storage Accounts you start of with. The more the better.

### Advanced usage

It is possible to have multiple instances of Hydra, configured to point at different and/or the same Storage Accounts, with different and/or the same ISharding implementations. That feature gives the developer maximum flexibility for making sure the right data is distributed in the right way.

### Example

Example usage can be found in the Hydra.Tests.Integration namespace.
