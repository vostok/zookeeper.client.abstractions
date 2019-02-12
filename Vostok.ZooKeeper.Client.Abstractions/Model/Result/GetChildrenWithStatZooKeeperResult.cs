using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.
    public class GetChildrenWithStatZooKeeperResult : ZooKeeperResult<Tuple<string[], Stat>>
    {
        public string[] Children => Payload.Item1;
        public Stat Stat => Payload.Item2;

        public GetChildrenWithStatZooKeeperResult(ZooKeeperStatus status, string path, string[] childrenNames, Stat stat)
            : base(status, path, new Tuple<string[], Stat>(childrenNames, stat))
        {
        }
    }
}