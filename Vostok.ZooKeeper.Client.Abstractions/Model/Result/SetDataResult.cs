using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents ZooKeeper set data result.</para>
    /// <para>Possible unsuccessful statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.VersionsMismatch"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class SetDataResult : ZooKeeperResult<NodeStat>
    {
        private SetDataResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] NodeStat stat)
            : base(status, path, stat)
        {
        }

        /// <summary>
        /// Creates a new instance of successful <see cref="SetDataResult"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        /// <param name="stat">Stat of node.</param>
        public static SetDataResult Successful([NotNull] string path, [NotNull] NodeStat stat) =>
            new SetDataResult(ZooKeeperStatus.Ok, path, stat);

        /// <summary>
        /// Creates a new instance of unsuccessful <see cref="SetDataResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="exception">Exception occured during execution.</param>
        public static SetDataResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new SetDataResult(status, path, null) { Exception = exception };

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        public NodeStat Stat => Payload;
    }
}