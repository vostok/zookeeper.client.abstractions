using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    public class GetDataZooKeeperRequest : GetZooKeeperRequest
    {
        public GetDataZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }
    }
}