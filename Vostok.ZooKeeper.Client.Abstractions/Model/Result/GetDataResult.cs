using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.
    public class GetDataResult : ZooKeeperResult<Tuple<byte[], NodeStat>>
    {
        public byte[] Data => Payload.Item1;
        public NodeStat Stat => Payload.Item2;

        public GetDataResult(ZooKeeperStatus status, string path, byte[] data, NodeStat stat)
            : base(status, path, new Tuple<byte[], NodeStat>(data, stat))
        {
        }
    }
}