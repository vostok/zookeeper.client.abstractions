using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="DeleteRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.VersionsMismatch"/> (if <see cref="DeleteRequest.Version"/> is specified)</description></item>
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

        public static DeleteResult Successful([NotNull] string path) =>
            new DeleteResult(ZooKeeperStatus.Ok, path);

        public static DeleteResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new DeleteResult(status, path) {Exception = exception};

        /// <inheritdoc />
        public override bool IsSuccessful => Status == ZooKeeperStatus.Ok || Status == ZooKeeperStatus.NodeNotFound;
    }
}