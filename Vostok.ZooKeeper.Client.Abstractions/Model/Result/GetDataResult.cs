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
        /// <summary>
        /// Creates a new instance of <see cref="CreateResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="data">Data of node.</param>
        /// <param name="stat">Stat of node.</param>
        public GetDataResult(ZooKeeperStatus status, string path, byte[] data, NodeStat stat)
            : base(status, path, (data, stat))
        {
        }

        /// <summary>
        /// Returns data of node.
        /// </summary>
        public byte[] Data => Payload.data;

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        public NodeStat Stat => Payload.stat;
    }
}