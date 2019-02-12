namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class ExistsZooKeeperResult : ZooKeeperResult<Stat>
    {
        public bool Exists => Payload != null;
        public Stat Stat => Payload;

        public ExistsZooKeeperResult(ZooKeeperStatus status, string path, Stat stat)
            : base(status, path, stat)
        {
        }
    }
}