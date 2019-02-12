using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    public abstract class GetZooKeeperRequest : ZooKeeperRequest
    {
        public IWatcher Watcher { get; }

        public GetZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path)
        {
            Watcher = watcher;
        }
    }
}