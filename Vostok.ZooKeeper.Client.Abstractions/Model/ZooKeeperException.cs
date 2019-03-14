using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents an exception that can only be thrown from <see cref="ZooKeeperResult.EnsureSuccess"/> and denotes a failure of ZK operation.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperException : Exception
    {
        public ZooKeeperException(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception)
            : base($"ZooKeeper operation has failed with status '{status}' for path '{path}'.", exception)
        {
        }
    }
}