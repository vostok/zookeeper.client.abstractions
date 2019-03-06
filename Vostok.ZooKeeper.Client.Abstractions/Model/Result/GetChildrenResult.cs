using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents ZooKeeper get children result.</para>
    /// <para>Possible unsuccessful statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class GetChildrenResult : ZooKeeperResult<(IReadOnlyList<string> childrenNames, NodeStat stat)>
    {
        private GetChildrenResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] [ItemNotNull] List<string> childrenNames, [CanBeNull] NodeStat stat)
            : base(status, path, (childrenNames, stat))
        {
        }

        /// <summary>
        /// Creates a new instance of successful <see cref="GetChildrenResult"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        /// <param name="childrenNames">Node children names.</param>
        /// <param name="stat">Stat of node.</param>
        public static GetChildrenResult Successful([NotNull] string path, [NotNull] [ItemNotNull] List<string> childrenNames, [CanBeNull] NodeStat stat) =>
            new GetChildrenResult(ZooKeeperStatus.Ok, path, childrenNames, stat);

        /// <summary>
        /// Creates a new instance of unsuccessful <see cref="GetChildrenResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="exception">Exception occured during execution.</param>
        public static GetChildrenResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new GetChildrenResult(status, path, null, null) {Exception = exception};

        /// <summary>
        /// Returns unordered children names (not absolute paths) of the node.
        /// </summary>
        [NotNull]
        [ItemNotNull]
        public IReadOnlyList<string> ChildrenNames => Payload.childrenNames;

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        [NotNull]
        public NodeStat Stat => Payload.stat;
    }
}