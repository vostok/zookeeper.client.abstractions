using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents node changed event type.
    /// </summary>
    [PublicAPI]
    public enum NodeChangedEventType
    {
        /// <summary>
        /// Node was created.
        /// </summary>
        Created,

        /// <summary>
        /// Node was deleted.
        /// </summary>
        Deleted,

        /// <summary>
        /// Node data was changed.
        /// </summary>
        DataChanged,

        /// <summary>
        /// Node children was changed.
        /// </summary>
        ChildrenChanged,

        /// <summary>
        /// <para>ZooKeeper client that create <see cref="INodeWatcher"/> changed connection state.</para>
        /// <para>In this case, event path will be null.</para>
        /// </summary>
        ConnectionStateChanged
    }
}