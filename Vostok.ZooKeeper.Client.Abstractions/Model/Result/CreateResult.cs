using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="CreateRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeAlreadyExists"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.ChildrenForEphemeralAreNotAllowed"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/> (if <see cref="CreateRequest.CreateParentsIfNeeded"/> is not specified)</description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class CreateResult : ZooKeeperResult<string>
    {
        private CreateResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] string newPath)
            : base(status, path, newPath)
        {
        }

        public static CreateResult Successful([NotNull] string path, [NotNull] string newPath) =>
            new CreateResult(ZooKeeperStatus.Ok, path, newPath);

        public static CreateResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new CreateResult(status, path, null) {Exception = exception};

        /// <summary>
        /// Returns path of created node.
        /// </summary>
        [NotNull]
        public string NewPath => Payload;
    }
}