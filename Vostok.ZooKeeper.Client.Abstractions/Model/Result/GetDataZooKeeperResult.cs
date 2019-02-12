using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.
    public class GetDataZooKeeperResult : ZooKeeperResult<Tuple<byte[], Stat>>
    {
        public byte[] Data => Payload.Item1;
        public Stat Stat => Payload.Item2;

        public GetDataZooKeeperResult(ZooKeeperStatus status, string path, byte[] data, Stat stat)
            : base(status, path, new Tuple<byte[], Stat>(data, stat))
        {
        }
    }
}