using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper get children.
    /// </summary>
    [PublicAPI]
    public class GetChildrenZooKeeperRequest : GetZooKeeperRequest
    {
        public GetChildrenZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }

        public override string ToString() => $"GET CHILDREN {base.ToString()}";
    }
}