using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Authentication;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// <para>Represents a result of handling a <see cref="GetAclRequest"/>.</para>
    /// <para>Common error statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class GetAclResult : ZooKeeperResult<(List<Acl> acls, NodeStat stat)>
    {
        private GetAclResult(ZooKeeperStatus status, [NotNull] string path, [NotNull] List<Acl> acls, [CanBeNull] NodeStat stat)
            : base(status, path, (acls, stat))
        {
        }

        public static GetAclResult Successful([NotNull] string path, [NotNull] List<Acl> acls, [NotNull] NodeStat stat) =>
            new GetAclResult(ZooKeeperStatus.Ok, path, acls, stat);

        public static GetAclResult Unsuccessful(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] Exception exception) =>
            new GetAclResult(status, path, new List<Acl>(), null) {Exception = exception};

        /// <summary>
        /// Returns the data of the queried node.
        /// </summary>
        [NotNull]
        public IReadOnlyList<Acl> Acls => Payload.acls;

        /// <summary>
        /// Returns the stat of the queried node.
        /// </summary>
        [NotNull]
        public NodeStat Stat => Payload.stat;
    }
}