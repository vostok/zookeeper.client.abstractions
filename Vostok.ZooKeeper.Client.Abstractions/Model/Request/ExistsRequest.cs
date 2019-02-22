using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper exists node request.
    /// </summary>
    [PublicAPI]
    public class ExistsRequest : GetRequest
    {
        public ExistsRequest([NotNull] string path, INodeWatcher watcher = null)
            : base(path, watcher)
        {
        }

        public override string ToString() => $"EXISTS {base.ToString()}";
    }
}