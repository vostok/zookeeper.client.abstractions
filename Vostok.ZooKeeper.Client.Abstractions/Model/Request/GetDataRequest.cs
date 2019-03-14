using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <inheritdoc/>
    [PublicAPI]
    public class GetDataRequest : GetRequest
    {
        /// <param name="path">Full path to the node being queried.</param>
        public GetDataRequest([NotNull] string path)
            : base(path)
        {
        }

        public override string ToString() => $"GET DATA of '{Path}'";

        public static implicit operator GetDataRequest([NotNull] string path) => new GetDataRequest(path);
    }
}