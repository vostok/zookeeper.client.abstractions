using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper child nodes listing request.
    /// </summary>
    [PublicAPI]
    public class GetChildrenRequest : GetRequest
    {
        /// <param name="path">Full path to the node being queried.</param>
        public GetChildrenRequest([NotNull] string path)
            : base(path)
        {
        }

        public override string ToString() => $"GET CHILDREN of '{Path}'";

        public static implicit operator GetChildrenRequest([NotNull] string path) => new GetChildrenRequest(path);
    }
}