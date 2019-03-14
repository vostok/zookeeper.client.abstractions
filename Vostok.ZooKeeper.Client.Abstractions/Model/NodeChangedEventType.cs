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
        /// Node children list was changed (some were created or deleted).
        /// </summary>
        ChildrenChanged
    }
}