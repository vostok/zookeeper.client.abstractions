using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper delete node request.
    /// </summary>
    [PublicAPI]
    public class DeleteRequest : ZooKeeperRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// <para>Creates a new instance of <see cref="DeleteRequest"/>.</para>
        /// <para>By default, all children nodes will be deleted if they exist.</para>
        /// </summary>
        /// <param name="path">Path of node.</param>
        public DeleteRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// <para>Request will be successful if <see cref="Version"/> matches the current version of the node.</para>
        /// <para>If the given version is -1, it matches any node's versions.</para>
        /// </summary>
        public int Version { get; set; } = -1;

        /// <summary>
        /// <para>Request will be successful if <see cref="DeleteChildrenIfNeeded"/> are specified or node have not any one.</para>
        /// <para>If the <see cref="DeleteChildrenIfNeeded"/> and <see cref="Version"/> are specified, and node version is changed during request execution,
        ///     all children will be deleted, but result will be <see cref="ZooKeeperStatus.VersionsMismatch"/> and node will not be deleted. </para>
        /// </summary>
        public bool DeleteChildrenIfNeeded { get; set; } = true;

        /// <summary>
        /// Returns string representation of <see cref="DeleteRequest"/>.
        /// </summary>
        public override string ToString() => $"DELETE {base.ToString()}, {nameof(Version)}: {Version}, {nameof(DeleteChildrenIfNeeded)}: {DeleteChildrenIfNeeded}";

        /// <summary>
        /// <para>Creates a new instance of <see cref="DeleteRequest"/> with given <paramref name="path"/>.</para>
        /// <para>All children nodes will be deleted if they exist.</para>
        /// </summary>
        public static implicit operator DeleteRequest([NotNull] string path) => new DeleteRequest(path);
    }
}