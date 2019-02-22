using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper get children.
    /// </summary>
    [PublicAPI]
    public class GetChildrenRequest : GetRequest
    {
        public GetChildrenRequest([NotNull] string path, INodeWatcher watcher = null)
            : base(path, watcher)
        {
        }

        public override string ToString() => $"GET CHILDREN {base.ToString()}";
    }
}