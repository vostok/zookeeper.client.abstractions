using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public abstract class ZooKeeperRequest
    {
        protected ZooKeeperRequest([NotNull] string path)
        {
            Path = path;
        }

        [NotNull]
        public string Path { get; }
    }

    [PublicAPI]
    public class CreateZooKeeperRequest : ZooKeeperRequest
    {
        public byte[] Data { get; }
        public CreateMode CreateMode { get; }
        public bool WithProtection { get; }

        public CreateZooKeeperRequest(string path, byte[] data, CreateMode createMode, bool withProtection = false)
            : base(path)
        {
            Data = data;
            CreateMode = createMode;
            WithProtection = withProtection;
        }
    }

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

    [PublicAPI]
    public class SetDataZooKeeperRequest : ZooKeeperRequest
    {
        public byte[] Data { get; }
        public int Version { get; }

        public SetDataZooKeeperRequest(string path, byte[] data, int version = -1)
            : base(path)
        {
            Data = data;
            Version = version;
        }
    }

    public abstract class GetZooKeeperRequest : ZooKeeperRequest
    {
        public IWatcher Watcher { get; }

        public GetZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path)
        {
            Watcher = watcher;
        }
    }

    public class ExistsZooKeeperRequest : GetZooKeeperRequest
    {
        public ExistsZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }
    }

    public class GetChildrenZooKeeperRequest : GetZooKeeperRequest
    {
        public GetChildrenZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }
    }

    public class GetDataZooKeeperRequest : GetZooKeeperRequest
    {
        public GetDataZooKeeperRequest([NotNull] string path, IWatcher watcher = null)
            : base(path, watcher)
        {
        }
    }
}