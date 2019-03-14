using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <inheritdoc />
    [PublicAPI]
    public class ExistsRequest : GetRequest
    {
        /// <param name="path">Full path to the node being queried.</param>
        public ExistsRequest([NotNull] string path)
            : base(path)
        {
        }

        public override string ToString() => $"EXISTS '{Path}'";

        public static implicit operator ExistsRequest([NotNull] string path) => new ExistsRequest(path);
    }
}