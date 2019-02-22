namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class DeleteResult : ZooKeeperResult
    {
        public DeleteResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }
    }
}