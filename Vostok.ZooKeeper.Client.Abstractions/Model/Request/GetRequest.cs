using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// <para>Represents ZooKeeper read request with an optional <see cref="INodeWatcher"/> to subscribe for node changes.</para>
    /// <para>See <see cref="Watcher"/> property for more details on how watchers work.</para>
    /// </summary>
    [PublicAPI]
    public abstract class GetRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being queried.</param>
        protected GetRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// <para>If the watcher is specified and the operation is successful, a watcher will be left on the node with the given path.</para>
        /// <para>The watcher will be triggered by a successful operation that sets data on the node, creates or deletes the node.</para>
        /// <para>The watcher will be triggered only once.</para>
        /// </summary>
        [CanBeNull]
        public INodeWatcher Watcher { get; set; }

        /// <summary>
        /// Whether or not to wrap watcher for deduplicate node events.
        /// </summary>
        public bool IgnoreWatchersCache { get; set; }

        public override string ToString() => $"Get '{Path}'";
    }
}