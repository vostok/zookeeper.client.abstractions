using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="GetDataRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class GetDataResult : ZooKeeperResult<(byte[] data, NodeStat stat)>
    {
        private GetDataResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] byte[] data, [CanBeNull] NodeStat stat)
            : base(status, path, (data, stat))
        {
        }

        public static GetDataResult Successful([NotNull] string path, [CanBeNull] byte[] data, [NotNull] NodeStat stat) =>
            new GetDataResult(ZooKeeperStatus.Ok, path, data, stat);

        public static GetDataResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new GetDataResult(status, path, null, null) {Exception = exception};

        /// <summary>
        /// Returns the data of the queried node.
        /// </summary>
        [CanBeNull]
        public byte[] Data => Payload.data;

        /// <summary>
        /// Returns the stat of the queried node.
        /// </summary>
        [NotNull]
        public NodeStat Stat => Payload.stat;
    }
}