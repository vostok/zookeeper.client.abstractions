namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class SetDataResult : ZooKeeperResult
    {
        public SetDataResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }
    }
}