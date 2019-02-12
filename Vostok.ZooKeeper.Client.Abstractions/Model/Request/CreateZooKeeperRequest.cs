using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
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
}