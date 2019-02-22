namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    public class GetChildrenResult : ZooKeeperResult<string[]>
    {
        public string[] Children => Payload;

        public GetChildrenResult(ZooKeeperStatus status, string path, string[] childrenNames)
            : base(status, path, childrenNames)
        {
        }
    }
}