namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class DeleteZooKeeperResult : ZooKeeperResult
    {
        public DeleteZooKeeperResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }
    }
}