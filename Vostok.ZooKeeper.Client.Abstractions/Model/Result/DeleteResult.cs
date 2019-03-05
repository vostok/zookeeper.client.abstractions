using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents ZooKeeper delete node result.</para>
    /// <para>Possible unsuccessful statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.VersionsMismatch"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.NodeHasChildren"/> (if <see cref="DeleteRequest.DeleteChildrenIfNeeded"/> is not specified)</description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class DeleteResult : ZooKeeperResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="DeleteResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        public DeleteResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }

        /// <inheritdoc />
        public override bool IsSuccessful => Status == ZooKeeperStatus.Ok || Status == ZooKeeperStatus.NodeNotFound;
    }
}