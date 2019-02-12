namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class SetDataZooKeeperResult : ZooKeeperResult
    {
        public SetDataZooKeeperResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }
    }
}