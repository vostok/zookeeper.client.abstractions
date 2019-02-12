using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
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
    }
}