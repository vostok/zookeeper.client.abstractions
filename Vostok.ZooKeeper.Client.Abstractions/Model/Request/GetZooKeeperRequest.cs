using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents base ZooKeeper get node request with <see cref="INodeWatcher"/> on node changes.
    /// </summary>
    [PublicAPI]
    public abstract class GetZooKeeperRequest : ZooKeeperRequest
    {
        public INodeWatcher Watcher { get; }

        public GetZooKeeperRequest([NotNull] string path, INodeWatcher watcher = null)
            : base(path)
        {
            Watcher = watcher;
        }

        public override string ToString() => $"{base.ToString()}";
    }
}