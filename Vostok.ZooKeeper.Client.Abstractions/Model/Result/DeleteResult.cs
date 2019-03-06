using System;
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
        private DeleteResult(ZooKeeperStatus status, [NotNull] string path)
            : base(status, path)
        {
        }

        /// <summary>
        /// Creates a new instance of successful <see cref="DeleteResult"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        public static DeleteResult Successful([NotNull] string path) =>
            new DeleteResult(ZooKeeperStatus.Ok, path);

        /// <summary>
        /// Creates a new instance of unsuccessful <see cref="DeleteResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="exception">Exception occured during execution.</param>
        public static DeleteResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new DeleteResult(status, path) {Exception = exception};

        /// <inheritdoc />
        public override bool IsSuccessful => Status == ZooKeeperStatus.Ok || Status == ZooKeeperStatus.NodeNotFound;
    }
}