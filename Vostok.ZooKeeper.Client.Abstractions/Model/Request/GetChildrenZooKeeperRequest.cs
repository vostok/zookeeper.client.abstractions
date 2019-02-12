using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    public class GetChildrenZooKeeperRequest : GetZooKeeperRequest
    {
        public GetChildrenZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }
    }
}