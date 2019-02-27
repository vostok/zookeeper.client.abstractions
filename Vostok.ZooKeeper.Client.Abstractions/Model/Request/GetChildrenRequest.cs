using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper get children.
    /// </summary>
    [PublicAPI]
    public class GetChildrenRequest : GetRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="GetChildrenRequest"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        public GetChildrenRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// Returns string representation of <see cref="GetChildrenRequest"/>.
        /// </summary>
        public override string ToString() => $"GET CHILDREN {base.ToString()}";
    }
}