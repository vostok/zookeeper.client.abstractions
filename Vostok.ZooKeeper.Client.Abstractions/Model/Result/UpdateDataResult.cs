using System;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="UpdateDataRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    ///     <item><description><see cref="ZooKeeperStatus.VersionsMismatch"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class UpdateDataResult : ZooKeeperResult
    {
        private UpdateDataResult(ZooKeeperStatus status, [NotNull] string path)
            : base(status, path)
        {
        }

        public static UpdateDataResult Successful([NotNull] string path) =>
            new UpdateDataResult(ZooKeeperStatus.Ok, path);

        public static UpdateDataResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new UpdateDataResult(status, path) {Exception = exception};
    }
}