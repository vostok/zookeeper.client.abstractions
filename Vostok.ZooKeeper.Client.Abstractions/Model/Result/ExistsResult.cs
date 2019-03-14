using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents a result of handling an <see cref="ExistsRequest"/>.
    /// </summary>
    [PublicAPI]
    public class ExistsResult : ZooKeeperResult<NodeStat>
    {
        private ExistsResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] NodeStat stat)
            : base(status, path, stat)
        {
        }

        public static ExistsResult Successful([NotNull] string path, [CanBeNull] NodeStat stat) =>
            new ExistsResult(ZooKeeperStatus.Ok, path, stat);

        public static ExistsResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new ExistsResult(status, path, null) {Exception = exception};

        /// <summary>
        /// Stat of the queried node. May be <c>null</c> if node does not exist.
        /// </summary>
        [CanBeNull]
        public NodeStat Stat => Payload;

        /// <summary>
        /// Returns whether the node exists.
        /// </summary>
        public bool Exists => Stat != null;
    }
}