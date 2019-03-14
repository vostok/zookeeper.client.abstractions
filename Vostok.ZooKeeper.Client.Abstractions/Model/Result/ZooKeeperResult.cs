using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents a ZooKeeper generic operation result with node path and status.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperResult
    {
        public ZooKeeperResult(ZooKeeperStatus status, [NotNull] string path)
        {
            Status = status;
            Path = path;
        }

        /// <summary>
        /// Returns <c>true</c> of this operation result is considered to be successful or <c>false</c> otherwise.
        /// </summary>
        public virtual bool IsSuccessful => Status == ZooKeeperStatus.Ok;

        /// <summary>
        /// Returns operation status.
        /// </summary>
        public ZooKeeperStatus Status { get; }

        /// <summary>
        /// Returns operation node's full path.
        /// </summary>
        [NotNull]
        public string Path { get; }

        /// <summary>
        /// Returns an optional exception that may accompany failed operation results.
        /// </summary>
        [CanBeNull]
        public Exception Exception { get; set; }

        /// <summary>
        /// Throws a <see cref="ZooKeeperException"/> if this result's <see cref="IsSuccessful"/> property returns <c>false</c>.
        /// </summary>
        public ZooKeeperResult EnsureSuccess()
        {
            if (!IsSuccessful)
                throw new ZooKeeperException(Status, Path, Exception);

            return this;
        }

        public override string ToString() => $"'{Status}' for path '{Path}'";
    }
}