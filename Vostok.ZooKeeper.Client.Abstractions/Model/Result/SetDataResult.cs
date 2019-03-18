using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="SetDataRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.VersionsMismatch"/> (if <see cref="SetDataRequest.Version"/> is specified)</description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class SetDataResult : ZooKeeperResult<NodeStat>
    {
        private SetDataResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] NodeStat stat)
            : base(status, path, stat)
        {
        }

        public static SetDataResult Successful([NotNull] string path, [NotNull] NodeStat stat) =>
            new SetDataResult(ZooKeeperStatus.Ok, path, stat);

        public static SetDataResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new SetDataResult(status, path, null) {Exception = exception};

        /// <summary>
        /// Returns the stat of the updated node.
        /// </summary>
        [NotNull]
        public NodeStat Stat => Payload;
    }
}