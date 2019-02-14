using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper exists node request.
    /// </summary>
    [PublicAPI]
    public class ExistsZooKeeperRequest : GetZooKeeperRequest
    {
        public ExistsZooKeeperRequest([NotNull] string path, INodeWatcher watcher = null)
            : base(path, watcher)
        {
        }

        public override string ToString() => $"EXISTS {base.ToString()}";
    }
}