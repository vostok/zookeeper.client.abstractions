using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="GetChildrenRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class GetChildrenResult : ZooKeeperResult<(IReadOnlyList<string> childrenNames, NodeStat stat)>
    {
        private GetChildrenResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] [ItemNotNull] IReadOnlyList<string> childrenNames, [CanBeNull] NodeStat stat)
            : base(status, path, (childrenNames, stat))
        {
        }

        public static GetChildrenResult Successful([NotNull] string path, [NotNull] [ItemNotNull] IReadOnlyList<string> childrenNames, [CanBeNull] NodeStat stat) =>
            new GetChildrenResult(ZooKeeperStatus.Ok, path, childrenNames, stat);

       
        public static GetChildrenResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new GetChildrenResult(status, path, null, null) {Exception = exception};

        /// <summary>
        /// Returns unordered names (not absolute paths) of the child nodes of the queried node.
        /// </summary>
        [NotNull]
        [ItemNotNull]
        public IReadOnlyList<string> ChildrenNames => Payload.childrenNames;

        /// <summary>
        /// Returns the stat of the queried node.
        /// </summary>
        [NotNull]
        public NodeStat Stat => Payload.stat;
    }
}