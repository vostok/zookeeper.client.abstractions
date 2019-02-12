using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
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
}