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
            Data = data ?? new byte[0];
            CreateMode = createMode;
            WithProtection = withProtection;
        }

        public override string ToString() => $"CREATE {base.ToString()}, {nameof(Data)} length: {Data.Length}, {nameof(CreateMode)}: {CreateMode}, {nameof(WithProtection)}: {WithProtection}";
    }
}