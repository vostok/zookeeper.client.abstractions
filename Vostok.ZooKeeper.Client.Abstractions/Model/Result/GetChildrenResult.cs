using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.

    /// <summary>
    /// <para>Represents ZooKeeper get children result.</para>
    /// <para>Possible unsuccessful statuses:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public class GetChildrenResult : ZooKeeperResult<Tuple<List<string>, NodeStat>>
    {
        /// <summary>
        /// Returns unordered children names (not absolute pathes) of the node.
        /// </summary>
        public List<string> ChildrenNames => Payload.Item1;

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        public NodeStat Stat => Payload.Item2;

        /// <summary>
        /// Creates a new instance of <see cref="CreateResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="childrenNames">Node children names.</param>
        /// <param name="stat">Stat of node.</param>
        public GetChildrenResult(ZooKeeperStatus status, string path, List<string> childrenNames, NodeStat stat)
            : base(status, path, new Tuple<List<string>, NodeStat>(childrenNames, stat))
        {
        }
    }
}