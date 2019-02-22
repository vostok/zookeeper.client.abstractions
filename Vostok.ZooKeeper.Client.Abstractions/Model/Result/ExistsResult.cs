namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class ExistsResult : ZooKeeperResult<NodeStat>
    {
        public bool Exists => Payload != null;
        public NodeStat NodeStat => Payload;

        public ExistsResult(ZooKeeperStatus status, string path, NodeStat nodeStat)
            : base(status, path, nodeStat)
        {
        }
    }
}