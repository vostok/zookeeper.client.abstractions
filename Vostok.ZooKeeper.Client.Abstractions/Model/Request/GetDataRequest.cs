using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper get data request.
    /// </summary>
    [PublicAPI]
    public class GetDataRequest : GetRequest
    {
        public GetDataRequest([NotNull] string path, INodeWatcher watcher = null)
            : base(path, watcher)
        {
        }

        public override string ToString() => $"GET DATA {base.ToString()}";
    }
}