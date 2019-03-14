using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents node creation mode.
    /// </summary>
    [PublicAPI]
    public enum CreateMode
    {
        /// <summary>
        /// <para>The node will not be automatically deleted upon owner client's session expiry.</para>
        /// </summary>
        Persistent = 0,

        /// <summary>
        /// <para>The node will be deleted upon the owner client's session expiry.</para>
        /// </summary>
        Ephemeral = 1,

        /// <summary>
        /// <para>The node will not be automatically deleted upon owner client's session expiry.</para>
        /// <para>A monotonically increasing (in the scope of parent node) number will be appended to node name.</para>
        /// </summary>
        PersistentSequential = 2,

        /// <summary>
        /// <para>The node will be deleted upon the owner client's session expiry.</para>
        /// <para>A monotonically increasing (in the scope of parent node) number will be appended to node name.</para>
        /// </summary>
        EphemeralSequential = 3
    }
}