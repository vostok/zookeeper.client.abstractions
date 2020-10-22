using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Authentication;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper data ACL setting request.
    /// </summary>
    [PublicAPI]
    public class SetAclRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being written to.</param>
        /// <param name="acls">Access lists being written to the node.</param>
        public SetAclRequest([NotNull] string path, [NotNull] List<Acl> acls)
            : base(path)
        {
            Acls = acls;
        }

        /// <summary>
        /// Access lists being written to the node.
        /// </summary>
        [NotNull]
        public IReadOnlyList<Acl> Acls { get; }

        /// <summary>
        /// <para>If set to value other than <c>-1</c>, write will only occur if node's current <see cref="NodeStat.AclVersion"/> equals provided one.</para>
        /// <para>Default value of <c>-1</c> disables version check.</para>
        /// </summary>
        public int AclVersion { get; set; } = -1;

        public override string ToString()
        {
            var acls = string.Join(",", Acls);
            return $"SET ACL for '{Path}'; ACLs = '{acls}'; AclVersion = {AclVersion}";
        }
    }
}