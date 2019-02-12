using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper delete node request.
    /// </summary>
    [PublicAPI]
    public class DeleteZooKeeperRequest : ZooKeeperRequest
    {
        public int Version { get; }
        public bool DeleteChildrenIfNeeded { get; }

        public DeleteZooKeeperRequest(string path, int version = -1, bool deleteChildrenIfNeeded = false)
            : base(path)
        {
            Version = version;
            DeleteChildrenIfNeeded = deleteChildrenIfNeeded;
        }

        public override string ToString() => $"DELETE {base.ToString()}, {nameof(Version)}: {Version}, {nameof(DeleteChildrenIfNeeded)}: {DeleteChildrenIfNeeded}";
    }
}