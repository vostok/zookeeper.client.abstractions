using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    public class ExistsZooKeeperRequest : GetZooKeeperRequest
    {
        public ExistsZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }
    }
}