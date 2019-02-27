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
        /// <summary>
        /// Creates a new instance of <see cref="CreateResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="stat">Stat of node.</param>
        public SetDataResult(ZooKeeperStatus status, string path, NodeStat stat)
            : base(status, path, stat)
        {
        }

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        public NodeStat Stat => Payload;
    }
}