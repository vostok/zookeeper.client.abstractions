using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper ACL and stat of the node request.
    /// </summary>
    [PublicAPI]
    public class GetAclRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being queried.</param>
        public GetAclRequest([NotNull] string path)
            : base(path)
        {
        }

        public override string ToString() => $"GET ACL of '{Path}'";

        public static implicit operator GetAclRequest([NotNull] string path) => new GetAclRequest(path);
    }
}