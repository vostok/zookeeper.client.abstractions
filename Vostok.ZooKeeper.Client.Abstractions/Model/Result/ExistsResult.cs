using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents ZooKeeper exists node result.
    /// </summary>
    [PublicAPI]
    public class ExistsResult : ZooKeeperResult<NodeStat>
    {
        private ExistsResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] NodeStat stat)
            : base(status, path, stat)
        {
        }

        /// <summary>
        /// Creates a new instance of successful <see cref="ExistsResult"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        /// <param name="stat">Stat of node.</param>
        public static ExistsResult Successful([NotNull] string path, [CanBeNull] NodeStat stat) =>
            new ExistsResult(ZooKeeperStatus.Ok, path, stat);

        /// <summary>
        /// Creates a new instance of unsuccessful <see cref="ExistsResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="exception">Exception occured during execution.</param>
        public static ExistsResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new ExistsResult(status, path, null) { Exception = exception };

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        [CanBeNull]
        public NodeStat Stat => Payload;
        
        /// <summary>
        /// Returns is node exists or not.
        /// </summary>
        public bool Exists => Stat != null;
    }
}