using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents exception that can only be thrown from <see cref="ZooKeeperResult.EnsureSuccess"/>.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="ZooKeeperException"/>
        /// </summary>
        /// <param name="status">ZooKeeper unsuccessful operation status.</param>
        /// <param name="path">ZooKeeper operation path.</param>
        /// <param name="exception">Inner exception.</param>
        public ZooKeeperException(ZooKeeperStatus status, string path, Exception exception)
            : base($"ZooKeeper operation has failed with status '{status}' for path '{path}'.", exception)
        {
        }
    }
}