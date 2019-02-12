namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class GetChildrenZooKeeperResult : ZooKeeperResult<string[]>
    {
        public string[] Children => Payload;

        public GetChildrenZooKeeperResult(ZooKeeperStatus status, string path, string[] childrenNames)
            : base(status, path, childrenNames)
        {
        }
    }
}