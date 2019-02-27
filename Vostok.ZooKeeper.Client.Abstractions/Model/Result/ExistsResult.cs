using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents ZooKeeper exists node result.
    /// </summary>
    [PublicAPI]
    public class ExistsResult : ZooKeeperResult<NodeStat>
    {
        /// <summary>
        /// Creates a new instance of <see cref="CreateResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="stat">Stat of node.</param>
        public ExistsResult(ZooKeeperStatus status, string path, NodeStat stat)
            : base(status, path, stat)
        {
        }

        /// <summary>
        /// Returns is node exists or not.
        /// </summary>
        public bool Exists => Payload != null;

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        public NodeStat Stat => Payload;
    }
}