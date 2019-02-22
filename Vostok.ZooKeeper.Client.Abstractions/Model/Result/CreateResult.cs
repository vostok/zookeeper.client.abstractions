namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class CreateResult : ZooKeeperResult<string>
    {
        public string NewPath => Payload;

        public CreateResult(ZooKeeperStatus status, string path, string newPath)
            : base(status, path, newPath)
        {
        }
    }
}