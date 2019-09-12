using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper node removal request.
    /// </summary>
    [PublicAPI]
    public class DeleteRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being deleted.</param>
        public DeleteRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// <para>If set to value other than <c>-1</c>, removal will only occur if node's current <see cref="NodeStat.Version"/> equals provided one.</para>
        /// <para>Default value of <c>-1</c> disables version check.</para>
        /// </summary>
        public int Version { get; set; } = -1;

        /// <summary>
        /// <para>If set to <c>true</c>, this option enables recursive removal of given node's child nodes.</para>
        /// <para>By default, removal fails if there is at least one child noe.</para>
        /// <para>If combined with <see cref="Version"/> check, this may lead to removal of child nodes without deleting requested node in the event of a race.</para>
        /// </summary>
        public bool DeleteChildrenIfNeeded { get; set; } = true;

        public override string ToString()
            => $"DELETE '{Path}'; Version = {Version}; Remove children = {DeleteChildrenIfNeeded}";

        public static implicit operator DeleteRequest([NotNull] string path) => new DeleteRequest(path);
    }
}