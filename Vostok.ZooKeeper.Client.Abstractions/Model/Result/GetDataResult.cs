﻿using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.

    /// <summary>
    /// <para>Represents ZooKeeper get data result.</para>
    /// <para>Possible unsuccessful statuses:</para>
    /// <list type="bullet">
    /// <item><description><see cref="ZooKeeperStatus.NodeNotFound"/></description></item>
    /// </list>
    /// </summary>
    public class GetDataResult : ZooKeeperResult<Tuple<byte[], NodeStat>>
    {
        /// <summary>
        /// Returns data of node.
        /// </summary>
        public byte[] Data => Payload.Item1;

        /// <summary>
        /// Returns stat of node.
        /// </summary>
        public NodeStat Stat => Payload.Item2;

        /// <summary>
        /// Creates a new instance of <see cref="CreateResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="data">Data of node.</param>
        /// <param name="stat">Stat of node.</param>
        public GetDataResult(ZooKeeperStatus status, string path, byte[] data, NodeStat stat)
            : base(status, path, new Tuple<byte[], NodeStat>(data, stat))
        {
        }
    }
}