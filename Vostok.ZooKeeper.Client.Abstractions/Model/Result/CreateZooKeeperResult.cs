namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class CreateZooKeeperResult : ZooKeeperResult<string>
    {
        public string NewPath => Payload;

        public CreateZooKeeperResult(ZooKeeperStatus status, string path, string newPath)
            : base(status, path, newPath)
        {
        }
    }
}