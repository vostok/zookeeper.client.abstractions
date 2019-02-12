using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents base ZooKeeper get node request with <see cref="IWatcher"/> on node changes.
    /// </summary>
    [PublicAPI]
    public abstract class GetZooKeeperRequest : ZooKeeperRequest
    {
        public IWatcher Watcher { get; }

        public GetZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path)
        {
            Watcher = watcher;
        }

        public override string ToString() => $"{base.ToString()}";
    }
}