using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper create node request.
    /// </summary>
    [PublicAPI]
    public class CreateRequest : ZooKeeperRequest
    {
        public byte[] Data { get; }
        public CreateMode CreateMode { get; }
        public bool WithProtection { get; }

        public CreateRequest(string path, byte[] data, CreateMode createMode, bool withProtection = false)
            : base(path)
        {
            Data = data ?? new byte[0];
            CreateMode = createMode;
            WithProtection = withProtection;
        }

        public override string ToString() => $"CREATE {base.ToString()}, {nameof(Data)} length: {Data.Length}, {nameof(CreateMode)}: {CreateMode}, {nameof(WithProtection)}: {WithProtection}";
    }
}