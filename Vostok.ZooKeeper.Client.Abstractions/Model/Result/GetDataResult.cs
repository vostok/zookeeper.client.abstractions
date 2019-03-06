using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents ZooKeeper get data result.</para>
    /// <para>Possible unsuccessful statuses:</para>
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

        /// <summary>
        /// Creates a new instance of successful <see cref="GetDataResult"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        /// <param name="data">Data of node.</param>
        /// <param name="stat">Stat of node.</param>
        public static GetDataResult Successful([NotNull] string path, [CanBeNull] byte[] data, [NotNull] NodeStat stat) =>
            new GetDataResult(ZooKeeperStatus.Ok, path, data, stat);

        /// <summary>
        /// Creates a new instance of unsuccessful <see cref="GetDataResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="exception">Exception occured during execution.</param>
        public static GetDataResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new GetDataResult(status, path, null, null) {Exception = exception};

        /// <summary>
        /// Returns data of node.
        /// </summary>
        [CanBeNull]
        public byte[] Data => Payload.data;

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        [NotNull]
        public NodeStat Stat => Payload.stat;
    }
}