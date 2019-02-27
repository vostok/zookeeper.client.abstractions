using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// <para>Represents ZooKeeper get request with <see cref="INodeWatcher"/> on node changes.</para>
    /// <para>If the watcher is specified and the call is successful, a watcher will be left on the node with the given path.</para>
    /// <para>The watcher will be triggered by a successful operation that sets data on the node, creates or deletes the node.</para>
    /// <para>The watcher will be triggered only once.</para>
    /// </summary>
    [PublicAPI]
    public abstract class GetRequest : ZooKeeperRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="GetRequest"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        protected GetRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// <para>If the watcher is specified and the call is successful, a watcher will be left on the node with the given path.</para>
        /// <para>The watcher will be triggered by a successful operation that sets data on the node, creates or deletes the node.</para>
        /// <para>The watcher will be triggered only once.</para>
        /// </summary>
        public INodeWatcher Watcher { get; set; }

        /// <summary>
        /// Returns string representation of <see cref="GetRequest"/>.
        /// </summary>
        public override string ToString() => $"{base.ToString()}";
    }
}