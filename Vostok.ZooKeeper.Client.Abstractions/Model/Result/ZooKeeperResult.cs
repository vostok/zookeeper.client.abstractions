using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents base ZooKeeper node result with path and status.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="ZooKeeperResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        public ZooKeeperResult(ZooKeeperStatus status, string path)
        {
            Status = status;
            Path = path;
        }

        /// <summary>
        /// Checks that operation is successful.
        /// </summary>
        public virtual bool IsSuccessful => Status == ZooKeeperStatus.Ok;

        /// <summary>
        /// Returns operation status.
        /// </summary>
        public ZooKeeperStatus Status { get; private set; }

        /// <summary>
        /// Returns exception if unseccessful result.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Returns operation node path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Throws <see cref="ZooKeeperException"/> in case of unsuccessful operation status.
        /// </summary>
        public ZooKeeperResult EnsureSuccess()
        {
            if (!IsSuccessful)
                throw new ZooKeeperException(Status, Path, Exception);
            return this;
        }

        /// <summary>
        /// Returns string representation of <see cref="ZooKeeperResult"/>.
        /// </summary>
        public override string ToString() => $"'{Status}' for path '{Path}'";
    }
}