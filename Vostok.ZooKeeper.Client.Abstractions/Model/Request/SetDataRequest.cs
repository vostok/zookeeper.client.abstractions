using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper set data request.
    /// </summary>
    [PublicAPI]
    [PublicAPI]
    public class SetDataRequest : ZooKeeperRequest
    {
        public byte[] Data { get; }
        public int Version { get; }

        public SetDataRequest(string path, byte[] data, int version = -1)
            : base(path)
        {
            Data = data ?? new byte[0];
            Version = version;
        }

        public override string ToString() => $"SET DATA {base.ToString()}, {nameof(Data)} length: {Data.Length}, {nameof(Version)}: {Version}";
    }
}