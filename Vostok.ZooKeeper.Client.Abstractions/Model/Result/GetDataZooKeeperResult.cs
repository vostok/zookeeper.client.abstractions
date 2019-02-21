using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.
    public class GetDataZooKeeperResult : ZooKeeperResult<Tuple<byte[], NodeStat>>
    {
        public byte[] Data => Payload.Item1;
        public NodeStat NodeStat => Payload.Item2;

        public GetDataZooKeeperResult(ZooKeeperStatus status, string path, byte[] data, NodeStat nodeStat)
            : base(status, path, new Tuple<byte[], NodeStat>(data, nodeStat))
        {
        }
    }
}