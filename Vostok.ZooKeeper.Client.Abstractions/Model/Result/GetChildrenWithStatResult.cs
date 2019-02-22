using System;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.
    public class GetChildrenWithStatResult : ZooKeeperResult<Tuple<string[], NodeStat>>
    {
        public string[] Children => Payload.Item1;
        public NodeStat NodeStat => Payload.Item2;

        public GetChildrenWithStatResult(ZooKeeperStatus status, string path, string[] childrenNames, NodeStat nodeStat)
            : base(status, path, new Tuple<string[], NodeStat>(childrenNames, nodeStat))
        {
        }
    }
}