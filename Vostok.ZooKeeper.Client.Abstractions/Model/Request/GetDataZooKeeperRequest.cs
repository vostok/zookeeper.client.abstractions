using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper get data request.
    /// </summary>
    [PublicAPI]
    public class GetDataZooKeeperRequest : GetZooKeeperRequest
    {
        public GetDataZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }

        public override string ToString() => $"GET DATA {base.ToString()}";
    }
}