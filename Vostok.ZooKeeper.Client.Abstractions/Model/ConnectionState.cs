using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents ZooKeeper client connection state.
    /// </summary>
    [PublicAPI]
    public enum ConnectionState
    {
        /// <summary>
        /// Client is in the connected state.
        /// </summary>
        Connected,

        /// <summary>
        /// Client is connected to a read-only server.
        /// </summary>
        ConnectedReadonly,

        /// <summary>
        /// Client is in the disconnected state. The state of <see cref="CreateMode.Ephemeral"/> nodes is unknown.
        /// </summary>
        Disconnected,

        /// <summary>
        /// Client's current session has expired. All <see cref="CreateMode.Ephemeral"/> nodes should be recreated.
        /// </summary>
        Expired,

        /// <summary>
        /// Client is not usable any more.
        /// </summary>
        Died
    }
}