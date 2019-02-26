using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper delete node request.
    /// </summary>
    [PublicAPI]
    public class DeleteRequest : ZooKeeperRequest
    {
        /// <summary>
        /// <para>Request will be successful if <see cref="Version"/> matches the current version of the node.</para>
        /// <para>If the given version is -1, it matches any node's versions.</para>
        /// </summary>
        public int Version { get; set; } = -1;

        /// <summary>
        /// Request will be successful if <see cref="DeleteChildrenIfNeeded"/> are specified or node have not any one.
        /// </summary>
        public bool DeleteChildrenIfNeeded { get; }

        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="GetDataRequest"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        public DeleteRequest(string path)
            : base(path)
        {
        }

        /// <summary>
        /// Returns string representation of <see cref="DeleteRequest"/>.
        /// </summary>
        public override string ToString() => $"DELETE {base.ToString()}, {nameof(Version)}: {Version}, {nameof(DeleteChildrenIfNeeded)}: {DeleteChildrenIfNeeded}";
    }
}