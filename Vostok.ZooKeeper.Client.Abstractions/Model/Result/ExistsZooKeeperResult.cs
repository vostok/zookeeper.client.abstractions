namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class ExistsZooKeeperResult : ZooKeeperResult<NodeStat>
    {
        public bool Exists => Payload != null;
        public NodeStat NodeStat => Payload;

        public ExistsZooKeeperResult(ZooKeeperStatus status, string path, NodeStat nodeStat)
            : base(status, path, nodeStat)
        {
        }
    }
}