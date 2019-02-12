namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class CreateZooKeeperResult : ZooKeeperResult<string>
    {
        public string NewPath => Payload;

        public CreateZooKeeperResult(ZooKeeperStatus status, string path, string payload)
            : base(status, path, payload)
        {
        }
    }
}