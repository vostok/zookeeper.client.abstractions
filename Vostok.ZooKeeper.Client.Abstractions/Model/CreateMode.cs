using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents node create mode.
    /// </summary>
    [PublicAPI]
    public enum CreateMode
    {
        /// <summary>
        /// <para>The node will not be automatically deleted upon client's disconnect.</para>
        /// </summary>
        Persistent = 0,

        /// <summary>
        /// <para>The node will be deleted upon the client's disconnect.</para>
        /// </summary>
        Ephemeral = 1,

        /// <summary>
        /// <para>The node will not be automatically deleted upon client's disconnect.</para>
        /// <para>A monotonically increasing number will be appended to node name.</para>
        /// </summary>
        PersistentSequential = 2,

        /// <summary>
        /// <para>The node will be deleted upon the client's disconnect.</para>
        /// <para>A monotonically increasing number will be appended to node name.</para>
        /// </summary>
        EphemeralSequential = 3
    }
}